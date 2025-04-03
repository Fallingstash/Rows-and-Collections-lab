using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class NumberCorrecter : TextFile {
  public NumberCorrecter() { }

  private string regularEx = @"\((\d{1})(\d{2})\)\s(\d{3})-(\d{2})-(\d{2})";
  private string replacement = "38$1 $2 $3 $4 $5";
  
  public void FixNumber(string fileText) {
    Content = Regex.Replace(fileText, regularEx, replacement);
  }
}

