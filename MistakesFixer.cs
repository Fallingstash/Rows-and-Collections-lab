using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class MistakesFixer : TextFile {

  public Dictionary<string, List<string>> mistakesDictionary = new Dictionary<string, List<string>>();

  public MistakesFixer() { }

  public void FixWords(string fileText) {
    foreach (var correctWord in mistakesDictionary.Keys) {
      foreach (var mistake in mistakesDictionary[correctWord]) {
        fileText = Regex.Replace(fileText, $@"\b{mistake}\b", correctWord, RegexOptions.IgnoreCase);
      }
    }
    Content = fileText;
  }
}
