import subprocess
import os
from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.common.action_chains import ActionChains
import time
from bs4 import BeautifulSoup

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
    # Initialize a WebDriver (assuming Chrome for this example)
    options = webdriver.ChromeOptions()

    options.add_argument("--headless")
    options.add_argument("--window-size=1920,1080")
    driver = webdriver.Chrome(options=options)

    # Load the webpage
    driver.get("https://r.pl/")

    # Wait for the website to fully load
    WebDriverWait(driver, 10).until(EC.presence_of_element_located((By.XPATH, "/html/body/div[1]/div/div[3]/div[1]/section[2]/div/div[2]/div/div/div/div[2]/a/div/div[2]/div[1]/span")))

    # Find the element using XPath
    element = driver.find_element(By.XPATH, "/html/body/div[1]/div/div[3]/div[1]/section[2]/div/div[2]/div/div/div/div[2]/a/div/div[2]/div[1]/span")

    # Get the text of the element
    hotel_name = element.text

    # Save the hotel name to a CSV file
    with open('hotel_names.csv', 'w') as csv_file:
        csv_file.write(hotel_name + '\n')

    # Quit the driver
    driver.quit()
