// Инвентарь

/*
Данное приложение предназначено для простого взаимодействия с RPG-инвентарем:
1. Просмотр инвентаря;
2. Фильтрация данных внутри инвентаря.
*/

/*
Из чего состоит инвентарь:
- Предметы со следующими характеристиками:
        - Редкость предмета;
        - Стоимость предмета;
        - Тип предмета;
        - Вес предмета.
*/

#include <iostream>
#include <vector>
#include <string>
#include <limits>

using namespace std;

enum ItemType{
        armor,
        weapon,
        potion,
        other
};

enum Rarity{
        usually,
        rare,
        epic,
        legendary  // Исправлено: было legenagary
};

/// Распаковка типа предмета
string typeToString(ItemType type){
        switch(type){
                case armor: return "Броня";
                case weapon: return "Оружие";
                case potion: return "Зелье";
                case other: return "Другое";
                default: return "Такого типа не существует";
        }
};

// Распаковка редкости предмета
string rarityToString(Rarity rarity){
        switch(rarity){
                case usually: return "Обычный";     // Исправлено: было "Броня"
                case rare: return "Редкий";         // Исправлено: было "Оружие"
                case epic: return "Эпический";      // Исправлено: было "Зелье"
                case legendary: return "Легендарный"; // Исправлено: было "Другое" и legenagary
                default: return "Такой редкости не существует";
        }
};

struct Item{
        int id;
        string name;
        ItemType type;
        Rarity rarity;
        int value;
        double weight;
};

// Получение текущей вместимости инвенторя
double getTotalWeight(const vector<Item>&inventory){
        double total = 0;
        for (const auto& item : inventory){
                total += item.weight;
        }
        return total;
};

void listItems(const vector<Item> & inventory){
        if(inventory.empty()){
                cout << "Инвентарь пуст!" << endl;
                return;
        }
        
        cout << "\n=== Содержимое инвентаря ===" << endl;
        cout << "ID | Название | Тип | Редкость | Цена | Вес" << endl;
        cout << "----------------------------------------" << endl;
        
        for(const auto &item : inventory){
                cout << item.id << " | " << item.name << " | "
                << typeToString(item.type) << " | " << rarityToString(item.rarity) << " | " 
                << item.value << " | " << item.weight << endl;
        }
        cout << "Общий вес: " << getTotalWeight(inventory) << "/" << "?" << endl;
        cout << endl;
}

// Добавление предмета в инвентарь
bool addItem(vector<Item> &inventory, const Item &item, const double &maxWeight){
        if(getTotalWeight(inventory) + item.weight > maxWeight){
                cout << "Инвентарь переполнен! Нельзя добавить предмет \"" << item.name << "\"" << endl;
                return false;
        }
        inventory.push_back(item);
        cout << "Предмет \"" << item.name << "\" успешно добавлен" << endl;
        return true;
};

// Функция поиска предмета по ID
Item* findItemById(vector<Item> &inventory, int id){
        for(auto &item : inventory){
                if(item.id == id){
                        return &item;
                }
        }
        return nullptr;
}

// Функция поиска предмета по названию (частичное совпадение)
vector<int> findItemsByName(const vector<Item> &inventory, const string &name){
        vector<int> foundIds;
        for(const auto &item : inventory){
                if(item.name.find(name) != string::npos){
                        foundIds.push_back(item.id);
                }
        }
        return foundIds;
}

// Функция поиска предметов по типу
vector<int> findItemsByType(const vector<Item> &inventory, ItemType type){
        vector<int> foundIds;
        for(const auto &item : inventory){
                if(item.type == type){
                        foundIds.push_back(item.id);
                }
        }
        return foundIds;
}

// Функция поиска предметов по редкости
vector<int> findItemsByRarity(const vector<Item> &inventory, Rarity rarity){
        vector<int> foundIds;
        for(const auto &item : inventory){
                if(item.rarity == rarity){
                        foundIds.push_back(item.id);
                }
        }
        return foundIds;
}

// Функция поиска предметов в диапазоне цены
vector<int> findItemsByValueRange(const vector<Item> &inventory, int minValue, int maxValue){
        vector<int> foundIds;
        for(const auto &item : inventory){
                if(item.value >= minValue && item.value <= maxValue){
                        foundIds.push_back(item.id);
                }
        }
        return foundIds;
}

// Функция удаления предмета по ID
bool removeItemById(vector<Item> &inventory, int id){
        for(size_t i = 0; i < inventory.size(); i++){
                if(inventory[i].id == id){
                        cout << "Предмет \"" << inventory[i].name << "\" с ID " << id << " удален" << endl;
                        inventory.erase(inventory.begin() + i);
                        return true;
                }
        }
        cout << "Предмет с ID " << id << " не найден" << endl;
        return false;
}

// Функция удаления всех предметов по названию
int removeItemsByName(vector<Item> &inventory, const string &name){
        int count = 0;
        for(size_t i = 0; i < inventory.size();){
                if(inventory[i].name.find(name) != string::npos){
                        cout << "Удален предмет \"" << inventory[i].name << "\" с ID " << inventory[i].id << endl;
                        inventory.erase(inventory.begin() + i);
                        count++;
                } else {
                        i++;
                }
        }
        
        if(count == 0){
                cout << "Предметы с названием, содержащим \"" << name << "\", не найдены" << endl;
        }
        
        return count;
}

// Вспомогательная функция для отображения результатов поиска
void displaySearchResults(const vector<Item> &inventory, const vector<int> &ids, const string &searchCriteria){
        if(ids.empty()){
                cout << "По заданному критерию \"" << searchCriteria << "\" ничего не найдено" << endl;
                return;
        }
        
        cout << "\n=== Результаты поиска: " << searchCriteria << " ===" << endl;
        cout << "Найдено предметов: " << ids.size() << endl;
        
        for(int id : ids){
                for(const auto &item : inventory){
                        if(item.id == id){
                                cout << item.id << " | " << item.name << " | "
                                     << typeToString(item.type) << " | " << rarityToString(item.rarity) 
                                     << " | " << item.value << " | " << item.weight << endl;
                                break;
                        }
                }
        }
        cout << endl;
}

int main(){

        cout << "=== Система управления инвентарем ===\n" << endl;
        vector<Item> inventory;
        double maxWeight = 100.0;

        // Создаем предметы
        Item sword = {1, "Стальной меч", weapon, usually, 50, 5.0};
        Item dragonArmor = {2, "Драконья броня", armor, epic, 2500, 52.0};
        Item healthPotion = {3, "Лечебное зелье", potion, rare, 200, 1.0};
        Item ironSword = {4, "Железный меч", weapon, usually, 30, 4.5};
        Item manaPotion = {5, "Зелье маны", potion, rare, 150, 0.8};
        Item legendaryBow = {6, "Легендарный лук", weapon, legendary, 5000, 3.5};
        
        addItem(inventory, sword, maxWeight);
        addItem(inventory, dragonArmor, maxWeight);
        addItem(inventory, healthPotion, maxWeight);
        addItem(inventory, ironSword, maxWeight);
        addItem(inventory, manaPotion, maxWeight);
        addItem(inventory, legendaryBow, maxWeight);

        listItems(inventory);
        
        cout << "\n=== Тестирование функций поиска ===\n";
        
        // Поиск по ID
        Item* foundItem = findItemById(inventory, 3);
        if(foundItem){
                cout << "Найден предмет по ID 3: " << foundItem->name << endl;
        }
        
        // Поиск по названию
        vector<int> foundByName = findItemsByName(inventory, "меч");
        displaySearchResults(inventory, foundByName, "Поиск по слову 'меч'");
        
        // Поиск по типу (оружие)
        vector<int> foundByType = findItemsByType(inventory, weapon);
        displaySearchResults(inventory, foundByType, "Все виды оружия");
        
        // Поиск по редкости (редкие предметы)
        vector<int> foundByRarity = findItemsByRarity(inventory, rare);
        displaySearchResults(inventory, foundByRarity, "Редкие предметы");
        
        // Поиск по диапазону цены
        vector<int> foundByPrice = findItemsByValueRange(inventory, 100, 1000);
        displaySearchResults(inventory, foundByPrice, "Предметы ценой от 100 до 1000");
        
        cout << "\n=== Тестирование функций удаления ===\n";
        
        // Удаление по ID
        removeItemById(inventory, 2);
        listItems(inventory);
        
        // Удаление по названию
        removeItemsByName(inventory, "Зелье");
        listItems(inventory);
        
        // Попытка удалить несуществующий предмет
        removeItemById(inventory, 99);
        
        return 0;
}
// Самостоятельное задание:
// 1. Поиск предмета;
// 2. Удаление предмета.