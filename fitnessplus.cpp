#include <iostream>
#include <string>
#include <chrono>
#include <ctime>
#include <iomanip>

class Person {
private:
    std::string gender;
    std::string birth_str;
    double weight_pounds;
    double height_inches;

public:
    // Constructor
    Person() {}

    // Setters
    void setGender(const std::string& g) {
        gender = g;
    }

    void setBirthdate(const std::string& b) {
        birth_str = b;
    }

    void setWeight(double pounds) {
        weight_pounds = pounds;
    }

    void setHeight(double inches) {
        height_inches = inches;
    }

    // Getters
    std::string getGender() const {
        return gender;
    }

    std::string getBirthdate() const {
        return birth_str;
    }

    double getWeight() const {
        return weight_pounds;
    }

    double getHeight() const {
        return height_inches;
    }

    // Other member functions
    int computeAge() const {
        std::tm birthdate = {};
        std::istringstream ss(birth_str);
        ss >> std::get_time(&birthdate, "%Y-%m-%d");

        auto birth_tp = std::chrono::system_clock::from_time_t(std::mktime(&birthdate));
        auto now_tp = std::chrono::system_clock::now();
        auto diff = std::chrono::duration_cast<std::chrono::hours>((now_tp - birth_tp)).count() / 24 / 365;
        return static_cast<int>(diff);
    }

    double kgFromLb(double pounds) const {
        return pounds * 0.45359237;
    }

    double cmFromIn(double inches) const {
        return inches * 2.54;
    }

    double bodyMassIndex() const {
        double kg = kgFromLb(weight_pounds);
        double cm = cmFromIn(height_inches);
        return kg / (cm * cm) * 10000;
    }

    double basalMetabolicRate() const {
        int age = computeAge();
        double kg = kgFromLb(weight_pounds);
        double cm = cmFromIn(height_inches);
        
        if (gender == "F" || gender == "f") {
            return 447.593 + 9.247 * kg + 3.098 * cm - 4.330 * age;
        } else {
            return 88.362 + 13.397 * kg + 4.799 * cm - 5.677 * age;
        }
    }
};

int main() {
    Person person;

    // Get user input
    std::cout << "Please enter your gender (Male or Female): ";
    std::string gender;
    std::getline(std::cin, gender);
    person.setGender(gender);

    std::cout << "Enter your birthdate (YYYY-MM-DD): ";
    std::string birthdate;
    std::getline(std::cin, birthdate);
    person.setBirthdate(birthdate);

    std::cout << "Enter your weight in U.S. pounds: ";
    double weight;
    std::cin >> weight;
    person.setWeight(weight);

    std::cout << "Enter your height in U.S. inches: ";
    double height;
    std::cin >> height;
    person.setHeight(height);

    // Calculate health metrics
    int age = person.computeAge();
    double bmi = person.bodyMassIndex();
    double bmr = person.basalMetabolicRate();

    // Output results
    std::cout << std::fixed << std::setprecision(2);
    std::cout << "Age (years): " << age << std::endl;
    std::cout << "Weight (kg): " << person.kgFromLb(weight) << std::endl;
    std::cout << "Height (cm): " << person.cmFromIn(height) << std::endl;
    std::cout << "Body mass index: " << bmi << std::endl;
    std::cout << "Basal metabolic rate (kcal/day): " << std::setprecision(0) << bmr << std::endl;

    return 0;
}
