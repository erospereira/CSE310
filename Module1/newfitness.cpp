#include <iostream>
#include <string>
#include <chrono>
#include <ctime>
#include <iomanip>
#include <map>

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

    double dailyCalorieIntake() const {
        double bmr = basalMetabolicRate();
        return (bmr * 1.2); // Harris-Benedict equation for sedentary lifestyle
    }
};

int main() {
    std::map<std::string, Person> people; // Map to store Person objects with unique identifiers

    char addMore;
    do {
        Person person;

        // Get user input
        std::cout << "Enter person's name: ";
        std::string name;
        std::getline(std::cin, name);
        
        std::cout << "Please enter " << name << "'s gender (Male or Female): ";
        std::string gender;
        std::getline(std::cin, gender);
        person.setGender(gender);

        std::cout << "Enter " << name << "'s birthdate (YYYY-MM-DD): ";
        std::string birthdate;
        std::getline(std::cin, birthdate);
        person.setBirthdate(birthdate);

        std::cout << "Enter " << name << "'s weight in U.S. pounds: ";
        double weight;
        std::cin >> weight;
        person.setWeight(weight);

        std::cout << "Enter " << name << "'s height in U.S. inches: ";
        double height;
        std::cin >> height;
        person.setHeight(height);

        people[name] = person; // Add person to map

        std::cout << "Do you want to add another person? (Y/N): ";
        std::cin >> addMore;
        std::cin.ignore(); // Ignore newline character left in input buffer
    } while (addMore == 'Y' || addMore == 'y');

    // Output results for each person
    for (const auto& pair : people) {
        std::cout << "-----------------------------" << std::endl;
        std::cout << "Name: " << pair.first << std::endl;
        std::cout << "Age (years): " << pair.second.computeAge() << std::endl;
        std::cout << "Weight (kg): " << pair.second.kgFromLb(pair.second.getWeight()) << std::endl;
        std::cout << "Height (cm): " << pair.second.cmFromIn(pair.second.getHeight()) << std::endl;
        std::cout << "Body mass index: " << pair.second.bodyMassIndex() << std::endl;
        std::cout << "Basal metabolic rate (kcal/day): " << std::fixed << std::setprecision(0) << pair.second.basalMetabolicRate() << std::endl;
        std::cout << "Recommended daily calorie intake (kcal/day): " << std::fixed << std::setprecision(0) << pair.second.dailyCalorieIntake() << std::endl;
        std::cout << "-----------------------------" << std::endl;
    }

    return 0;
}
