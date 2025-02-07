using System.Security.Cryptography;
using System.Text;

namespace PSP_PasswordCracker;

public class PasswdEncoder
{


    private static readonly PasswdEncoder instancia = new PasswdEncoder();
    private PasswdEncoder() { }
    
    public static PasswdEncoder Instancia
    {
        get { return instancia; }
    }
    
    
    public String HashString(String toHash)
    {
        byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(toHash);
        return ByteArrayToString(new MD5CryptoServiceProvider().ComputeHash(tmpSource));
    }


    static string ByteArrayToString(byte[] arrInput)
    {
        int i;
        StringBuilder sOutput = new StringBuilder(arrInput.Length);
        for (i=0;i < arrInput.Length; i++)
        {
            sOutput.Append(arrInput[i].ToString("X2"));
        }
        return sOutput.ToString();
    }
}