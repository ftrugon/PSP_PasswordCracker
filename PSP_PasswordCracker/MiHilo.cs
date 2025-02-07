using System.Runtime.InteropServices.JavaScript;
using System.Security.Cryptography;
using System.Text;

namespace PSP_PasswordCracker;

public class MiHilo
{

    private String[] _passwords;
    private String hashToDiscover;
    private HilosController hc;
    private Thread hilo;
    
    
    public MiHilo(String[] passwords, String hashToDiscover, HilosController hc)
    {

        this.hc = hc;
        this._passwords = passwords;
        this.hashToDiscover = hashToDiscover;

        hilo = new Thread(() => CheckPassword(this._passwords,this.hashToDiscover));
    }
    

    public void Start()
    {
        hilo.Start();
    }

    void CheckPassword(String[] passwords, String correctHash)
    {

        bool success = false;

        foreach (var pass in passwords)
        {
            if (hc.bandera == false && success == false)
            {
                String hasheada = PasswdEncoder.Instancia.HashString(pass);
                if (hasheada == correctHash)
                {
                    Console.WriteLine($"Passwords Match --> {pass} --> {hasheada}");
                    success = true;
                    hc.bandera = true;
                    break;
                }
            }
            else
            {
                break;
            }

        }
    }


}