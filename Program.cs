using System.Collections.Generic;
using System;
using System.IO;

class Program {
  static void Main(string[] args) {
    Console.WriteLine("-------------------------------------------------");
    Console.WriteLine("Добро пожаловать в исправитель файлов!!!");
    Console.WriteLine("-------------------------------------------------");

    FileSearcher searcher = new FileSearcher();
    TextEditor fixer;
    Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

    bool appIsOpen = true;
    while (appIsOpen) {
      Console.WriteLine("Выберите действие");
      Console.WriteLine("1. Заполнить словарь для исправления слов.");
      Console.WriteLine("2. Ввести директорию для исправления.");
      Console.WriteLine("3. Выйти из программы.");
      Console.Write("Ваш выбор:");
      string userChoice = Console.ReadLine();

      switch (userChoice) {
        case "1":
          FillDictionary(dict);
          break;
        case "2":
          FixFilesInDirectory(searcher, dict);
          break;
        case "3":
          appIsOpen = false;
          break;
        default:
          Console.WriteLine("Неверный выбор. Попробуйте снова.");
          break;
      }

      Console.WriteLine("Нажмите любую клавишу для продолжения..");
      Console.ReadKey();
      Console.Clear();
    }
  }

  static void FillDictionary(Dictionary<string, List<string>> dict) {
    List<string> wrongWords = new List<string>();
    bool writingWrongWords = true;
    Console.WriteLine("Введите ПРАВИЛЬНУЮ версию слова, например \"привет\" ");
    string correctWord = Console.ReadLine();

    while (writingWrongWords) {
      Console.WriteLine("Введите поочередно слова для исправления, например \"привте\".\nДля того чтобы выйти из заполнения отправьте пустую строку.");
      string userInput = Console.ReadLine();
      if (userInput == "") {
        writingWrongWords = false;
        dict[correctWord] = wrongWords;
      } else {
        wrongWords.Add(userInput);
      }
    }
  }

  static void FixFilesInDirectory(FileSearher searcher, Dictionary<string, List<string>> dict) {
    Console.WriteLine("Введите путь к директории");
    string dirPath = Console.ReadLine();
    List<string> foundFiles = searcher.SearchFiles(dirPath);

    foreach (string file in foundFiles) {
      Console.WriteLine($"Текст файла {file}\n");
      Console.WriteLine(File.ReadAllText(file) + "\n");

      var fixer = new TextEditor(file);
      fixer.FixFile(dict);

      Console.WriteLine("Новый текст файла: \n");
      Console.WriteLine(File.ReadAllText(file) + "\n");
    }
  }
}