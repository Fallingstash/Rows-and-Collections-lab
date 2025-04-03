using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FileSearher {
  public List<string> files = new List<string>();
  public string directoryPath;

  public List<string> SearchFiles(string path) {
    directoryPath = path;
    if (!Directory.Exists(directoryPath)) {
      throw new DirectoryNotFoundException();
    }

    string[] filesInDir = Directory.GetFiles(path, "*.txt");
    foreach (string file in filesInDir) {
      files.Add(file);
    }
    
    return files;
  }
}
