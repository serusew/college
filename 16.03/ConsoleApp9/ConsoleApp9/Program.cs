using System;


Console.WriteLine("--- Задание 1 ---");
РисоватьКвадрат(4, '$'); 
Console.WriteLine("\n--- Задание 2 ---");
int число1 = 1221;
bool результат1 = ПроверкаНаПалиндром(число1);
Console.WriteLine("Число " + число1 + " это палиндром? Ответ: " + результат1);

int число2 = 7854;
bool результат2 = ПроверкаНаПалиндром(число2);
Console.WriteLine("Число " + число2 + " это палиндром? Ответ: " + результат2);

Console.WriteLine("\n--- Задание 3 ---");
int[] мойМассив = { 1, 2, 6, -1, 88, 7, 6 };
int[] фильтр = { 6, 88, 7 };

int[] готовыйМассив = ФильтрацияМассива(мойМассив, фильтр);

Console.Write("Результат фильтрации: ");
for (int i = 0; i < готовыйМассив.Length; i++)
{
    Console.Write(готовыйМассив[i] + " ");
}
Console.WriteLine();


Console.WriteLine("\n--- Задание 4: Класс Веб-сайт ---");
Website сайт = new Website();
сайт.Ввод();
Console.WriteLine("\nДанные, которые вы ввели:");
сайт.Вывод();

Console.WriteLine("\n--- Задание 5: Класс Журнал ---");
Journal журнал = new Journal();
журнал.ВводДанных();
Console.WriteLine("\nДанные журнала:");
журнал.ВыводДанных();

Console.WriteLine("\n--- Задание 6: Класс Магазин ---");
Shop магазин = new Shop();
магазин.Заполнить();
Console.WriteLine("\nДанные магазина:");
магазин.Показать();

static void РисоватьКвадрат(int сторона, char символ)
{
    for (int i = 0; i < сторона; i++)
    {
        for (int j = 0; j < сторона; j++)
        {
            Console.Write(символ + " ");
        }
        Console.WriteLine();
    }
}

static bool ПроверкаНаПалиндром(int число)
{
    string текст = число.ToString();
    int лево = 0;
    int право = текст.Length - 1;

    while (лево < право)
    {
        if (текст[лево] != текст[право])
        {
            return false;
        }
        лево = лево + 1;
        право = право - 1;
    }
    return true;
}

static int[] ФильтрацияМассива(int[] старыйМассив, int[] массивФильтр)
{
    int сколькоОстанется = 0;

    for (int i = 0; i < старыйМассив.Length; i++)
    {
        bool нашлиВФильтре = false;

        for (int j = 0; j < массивФильтр.Length; j++)
        {
            if (старыйМассив[i] == массивФильтр[j])
            {
                нашлиВФильтре = true;
            }
        }

        if (нашлиВФильтре == false)
        {
            сколькоОстанется = сколькоОстанется + 1;
        }
    }

    int[] новыйМассив = new int[сколькоОстанется];
    int индексНового = 0;

    for (int i = 0; i < старыйМассив.Length; i++)
    {
        bool нашлиВФильтре = false;

        for (int j = 0; j < массивФильтр.Length; j++)
        {
            if (старыйМассив[i] == массивФильтр[j])
            {
                нашлиВФильтре = true;
            }
        }

        if (нашлиВФильтре == false)
        {
            новыйМассив[индексНового] = старыйМассив[i];
            индексНового = индексНового + 1;
        }
    }

    return новыйМассив;
}

class Website
{
    private string name;
    private string url;
    private string description;
    private string ip;

    public string GetName() { return name; }
    public void SetName(string newName) { name = newName; }

    public string GetUrl() { return url; }
    public void SetUrl(string newUrl) { url = newUrl; }

    public string GetDescription() { return description; }
    public void SetDescription(string newDescription) { description = newDescription; }

    public string GetIp() { return ip; }
    public void SetIp(string newIp) { ip = newIp; }

    public void Ввод()
    {
        Console.Write("Введите имя сайта: ");
        name = Console.ReadLine();
        Console.Write("Введите адрес сайта: ");
        url = Console.ReadLine();
        Console.Write("Введите описание сайта: ");
        description = Console.ReadLine();
        Console.Write("Введите IP сайта: ");
        ip = Console.ReadLine();
    }

    public void Вывод()
    {
        Console.WriteLine("Имя сайта: " + name);
        Console.WriteLine("Ссылка: " + url);
        Console.WriteLine("Описание: " + description);
        Console.WriteLine("IP адрес: " + ip);
    }
}

class Journal
{
    private string name;
    private int year;
    private string description;
    private string phone;
    private string email;

    public string GetName() { return name; }
    public void SetName(string value) { name = value; }

    public int GetYear() { return year; }
    public void SetYear(int value) { year = value; }

    public string GetDescription() { return description; }
    public void SetDescription(string value) { description = value; }

    public string GetPhone() { return phone; }
    public void SetPhone(string value) { phone = value; }

    public string GetEmail() { return email; }
    public void SetEmail(string value) { email = value; }

    public void ВводДанных()
    {
        Console.Write("Название журнала: ");
        name = Console.ReadLine();
        Console.Write("Год создания: ");
        year = Convert.ToInt32(Console.ReadLine());
        Console.Write("Описание: ");
        description = Console.ReadLine();
        Console.Write("Телефон: ");
        phone = Console.ReadLine();
        Console.Write("Email: ");
        email = Console.ReadLine();
    }

    public void ВыводДанных()
    {
        Console.WriteLine("Журнал: " + name);
        Console.WriteLine("Основан в: " + year + " году");
        Console.WriteLine("О журнале: " + description);
        Console.WriteLine("Контакты: " + phone + ", " + email);
    }
}

class Shop
{
    private string name;
    private string address;
    private string profile;
    private string phone;
    private string email;

    public string GetName() { return name; }
    public void SetName(string value) { name = value; }

    public string GetAddress() { return address; }
    public void SetAddress(string value) { address = value; }

    public string GetProfile() { return profile; }
    public void SetProfile(string value) { profile = value; }

    public string GetPhone() { return phone; }
    public void SetPhone(string value) { phone = value; }

    public string GetEmail() { return email; }
    public void SetEmail(string value) { email = value; }

    public void Заполнить()
    {
        Console.Write("Название магазина: ");
        name = Console.ReadLine();
        Console.Write("Адрес магазина: ");
        address = Console.ReadLine();
        Console.Write("Профиль: ");
        profile = Console.ReadLine();
        Console.Write("Телефон: ");
        phone = Console.ReadLine();
        Console.Write("Email: ");
        email = Console.ReadLine();
    }

    public void Показать()
    {
        Console.WriteLine("Магазин: " + name);
        Console.WriteLine("Адрес: " + address);
        Console.WriteLine("Специализация: " + profile);
        Console.WriteLine("Телефон: " + phone);
        Console.WriteLine("Почта: " + email);
    }
}
