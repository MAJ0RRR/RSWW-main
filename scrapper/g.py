from selenium import webdriver
from bs4 import BeautifulSoup

# Initialize a WebDriver (assuming Chrome for this example)
driver = webdriver.Chrome()

# Load the webpage
driver.get("https://r.pl/wlochy")

html_content = driver.page_source

soup = BeautifulSoup(html_content, 'html.parser')

element = driver.find_element("xpath", '/html/body/div[1]/div/div[3]/div[1]/div/section[2]/section/div/div[2]/div[2]/a[3]/div/div[2]/div[1]/span')

# Print the found element
print(element.text)
driver.quit()
