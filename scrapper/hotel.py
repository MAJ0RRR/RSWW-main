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

from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
import csv

def scrap_hotels():
    options = webdriver.ChromeOptions()
    options.add_argument("--headless")
    options.add_argument("--window-size=1920,1080")
    driver = webdriver.Chrome(options=options)

    try:
        # Load the webpage
        driver.get("https://r.pl/")

        # Wait for the page to load and for span elements to be present
        WebDriverWait(driver, 20).until(
            EC.presence_of_all_elements_located((By.TAG_NAME, "span"))
        )

        # Find all span elements
        span_elements = driver.find_elements(By.TAG_NAME, "span")

        # Retrieve text from each span element
        span_texts = [element.text for element in span_elements if element.text.strip()]

        # Save the span texts to a CSV file
        with open('span_texts.csv', 'w', newline='', encoding='utf-8') as csv_file:
            writer = csv.writer(csv_file)
            writer.writerow(['Span Text'])
            for text in span_texts:
                writer.writerow([text])
        print(f"Successfully saved {len(span_texts)} span texts to 'span_texts.csv'.")

    except Exception as e:
        print(f"An error occurred: {e}")

    finally:
        # Quit the driver
        driver.quit()