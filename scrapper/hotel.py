import subprocess
import os

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
