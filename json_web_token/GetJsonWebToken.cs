using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace json_web_token {
  public class GetJsonWebToken {

    public static string Encode(string email, string certificateFilePath) {
      var utc0 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
      var issueTime = DateTime.Now;

      var iat = (int)issueTime.Subtract(utc0).TotalSeconds;
      var exp = (int)issueTime.AddMinutes(55).Subtract(utc0).TotalSeconds; // Expiration time is up to 1 hour, but lets play on safe side

      var payload = new {
        iss = email,
        scope = @"https://www.googleapis.com/auth/gan.readonly",
        aud = @"https://accounts.google.com/o/oauth2/token",
        exp = exp,
        iat = iat
      };

      //var certificate = new X509Certificate2(certificateFilePath, "notasecret");

      //var privateKey = certificate.Export(X509ContentType.Cert);

      var privateKey = "myNameIsSahil";

      return JsonWebToken.Encode(payload, privateKey, JwtHashAlgorithm.RS256);
    }
  }
}
