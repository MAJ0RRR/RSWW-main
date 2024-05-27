import subprocess
import os
from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
import json
import time


def generate_hotel_dbcontext(n):
    with open('dbcontexts_template/hotel_db_context.txt', 'r') as template:
        template_content = template.read()

    with open('dbcontexts_generated/hotel_db_context.txt', 'w') as dbcontext:
        dbcontext.write(template_content)

        gen_guids = f"""

            Guid[] hotelIds = new Guid[{n}];
                    for (int i = 0; i < hotelIds.Length; i++)
                    {{
                        hotelIds[i] = Guid.NewGuid();
                    }}

        """

        dbcontext.write(gen_guids)

        gen_hotels = """
            var hotels = new[]
            {
        """

        for i in range(n):
            new_hotel = f"""
            new Hotel
                {{
                    Id = hotel1Is[{i}], Name = "Berlin Hotel", FoodPricePerPerson = 20, City = "Berlin", Country = "Germany", Street = "Alexanderplatz"
                }},
            """
            gen_hotels = gen_hotels + new_hotel


        gen_hotels = gen_hotels + \
        """

            modelBuilder.Entity<Hotel>().HasData(hotels);
        """


        gen_hotels = gen_hotels + \
            """

            };

            modelBuilder.Entity<Hotel>().HasData(hotels);
        """

        dbcontext.write(gen_hotels)

        gen_rooms = """
            var rooms = new[]
            {
        """

        for i in range(n):
            new_room = """
            new Room { Id = Guid.NewGuid(), HotelId = hotel1Id, Size = 25, Price = 100, Count = 5 },
            """
            gen_rooms = gen_rooms + new_room

        gen_rooms = gen_rooms + \
            """
            };

            modelBuilder.Entity<Room>().HasData(rooms);
        """

        dbcontext.write(gen_rooms)
        dbcontext.write(
            """
        }
    }
}
        """
        )

def create_hotel_migration(name):
    command = ['dotnet', 'ef', 'migrations', 'add', name]

    script_directory = os.path.dirname(os.path.abspath(__file__))
    root_directory = os.path.dirname(script_directory)
    destination_directory = 'hotelservice'

    working_directory = os.path.join(root_directory, destination_directory)
    os.chdir(working_directory)
    print(os.getcwd())

    # Run the command
    subprocess.run(command)

def scrap_hotels():
    options = webdriver.ChromeOptions()
    # options.add_argument("--headless")
    options.add_argument("--window-size=1920,1080")
    driver = webdriver.Chrome(options=options)

    COUNTRIES = ['albania','grecja','turcja','hiszpania','egipt','chorwacja']
    # TRIP_TYPE_XPATH = '//*[@id="bloczkiHTMLID"]/a/div/div[2]/span'

    country_hotels = {}

    for country in COUNTRIES:
        # Load the webpage
        driver.get(f"https://r.pl/{country}")
        hotels_names = []

        WebDriverWait(driver, 20).until(
                EC.presence_of_element_located((By.XPATH, '//*[@id="bloczkiHTMLID"]/a/div/div[2]/div[1]/span'))
            )

        for i in range(1,9):
            HOTEL_NAME_XPATH = f'//*[@id="bloczkiHTMLID"]/a[{i}]/div/div[2]/div[1]/span'
            # Find hotels
            try:
                hotel = driver.find_element(By.XPATH, HOTEL_NAME_XPATH)

                while hotel.text == "":
                    time.sleep(1)
                    driver.execute_script("window.scrollBy(0, window.innerHeight * 0.25)")
                    # Find hotels again after scrolling
                    hotel = driver.find_element(By.XPATH, HOTEL_NAME_XPATH)
                    print("Waiting...")

                print(hotel.text)
                hotels_names.append(hotel.text)

            except Exception as e:
                print(f"Error occurred: {str(e)}")
        
        country_hotels[country] = hotels_names

    # Save the dictionary to a JSON file
    with open('Hotels.json', 'w') as json_file:
        json.dump(country_hotels, json_file)

    driver.quit()
