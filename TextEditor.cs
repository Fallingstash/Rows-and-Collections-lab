using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TextEditor {
  MistakesFixer fixer = new MistakesFixer();
  NumberCorrecter correcter = new NumberCorrecter();

  public TextEditor(string filePath) {
    fixer.FilePath = filePath;
    fixer.Content = File.ReadAllText(filePath);
    correcter.FilePath = filePath;
    correcter.Content = File.ReadAllText(filePath);
  }

  public void FixFile(Dictionary<string, List<string>> dict) {
    fixer.mistakesDictionary = dict;
    fixer.FixWords(fixer.Content);
    File.WriteAllText(fixer.FilePath, fixer.Content);
    correcter.FixNumber(fixer.Content);
    File.WriteAllText(correcter.FilePath, correcter.Content);
  }
}
