# Fitness App

The Fitness App is a C++ console application designed to help users track and analyze key health indicators such as Body Mass Index (BMI) and Basal Metabolic Rate (BMR). This application gathers user input on gender, birthdate, weight, and height, and uses these details to calculate and display their age, weight in kilograms, height in centimeters, BMI, and daily caloric needs (BMR).

## Features

- **Age Calculation:** Computes the user's age based on the birthdate provided.
- **Unit Conversion:** Converts weight from pounds to kilograms and height from inches to centimeters.
- **BMI Calculation:** Calculates the Body Mass Index to assess whether the user's weight is healthy relative to their height.
- **BMR Calculation:** Estimates the number of calories the user needs to maintain their body weight without additional activity, based on their age, gender, weight, and height.

## How to Use

1. **Start the application:** Run the executable file from the command line or double-click the file in your GUI file explorer.
2. **Enter details:**
    - Input your gender as Male or Female when prompted.
    - Enter your birthdate in the YYYY-MM-DD format.
    - Provide your weight in U.S. pounds.
    - Provide your height in U.S. inches.
3. **View Results:** After entering your details, the calculated age, weight (in kg), height (in cm), BMI, and BMR will be displayed on the screen.

## Requirements

- **Compiler:** C++17 compliant compiler (e.g., GCC, Clang, MSVC)
- **Operating System:** Windows, macOS, or Linux

## Building the App

To compile and run this application, ensure that your system has a compatible C++ compiler. Here is an example of how you can compile the program using `g++`:

```bash
g++ -std=c++17 -o FitnessApp FitnessApp.cpp
./FitnessApp
