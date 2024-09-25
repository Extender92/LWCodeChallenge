# LWCodeChallenge

## Project Overview

This project is part of the recruitment process for LearningWell. The goal is to create a software application that visually represents the EU statistics for “Activation of registered unemployed”. The application should present a graphical representation, preferably in the form of a bar or line chart, showing the number of activations over the years on the x-axis, and the count on the y-axis. Additionally, the application should display the relationship between men and women in the data.

The program should allow the user to specify the ISO code of the country for which the data is to be displayed.

## Features

- Graphical representation of EU statistics on “Activation of registered unemployed.”
- Displays data by year with counts on the y-axis.
- Shows gender comparison (male vs. female).
- Allows selection of country via ISO code parameter.

## Data Source

All data for this task is fetched from the EU’s open API:
- **API Endpoint**: [EU API - Activation of registered unemployed](https://webgate.ec.europa.eu/empl/redisstat/api/dissemination/sdmx/2.1/data/lmp_ind_actru?format=json&compressed=false)

Alternatively, you can explore the data via the EU’s data browser:
- [EU Data Browser](https://webgate.ec.europa.eu/empl/redisstat/databrowser/view/LMP_IND_ACTRU/default/table?lang=en)

For more information on available data formats, please visit:
- [EUROSTAT Data Format Guide](https://ec.europa.eu/eurostat/online-help/public/en/DOWNLOAD_availableformats_en/)

## Instructions

### Prerequisites
- Any programming or scripting language can be used for this challenge.
- A working internet connection is required to fetch data from the API.

### Running the Program
The application takes one input parameter: the ISO code of the country to display data for. For example, you can pass `SE` for Sweden, `DE` for Germany, etc.

### Graphical Presentation
The data should be presented graphically. A simple bar or line chart is recommended, with years on the x-axis and the activation counts on the y-axis. It should also show a comparison between male and female activation rates, if available.

Good luck and have fun solving the challenge!
