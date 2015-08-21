using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace json_web_token {
  class Program {
    static void Main(string[] args) {

      var encode = GetJsonWebToken.Encode("sahilravinder@gmail.com", "c:\temp");
      var decode = JsonWebToken.Decode(encode, "myNameIsSahil");
      int i = 0;
    }
  }
}
