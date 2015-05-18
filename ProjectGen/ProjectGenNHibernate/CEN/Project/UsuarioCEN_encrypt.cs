
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using ProjectGenNHibernate.EN.Project;
using ProjectGenNHibernate.CAD.Project;

namespace ProjectGenNHibernate.CEN.Project
{
public partial class UsuarioCEN : BasicCAD
{
public string Encrypt (string arg0)
{
        /*PROTECTED REGION ID(ProjectGenNHibernate.CEN.Project_Usuario_encrypt) ENABLED START*/

        // Write here your custom code...
        byte[] bIV =
        { 0x50, 0x08, 0xF1, 0xDD, 0xDE, 0x3C, 0xF2, 0x18,
          0x44, 0x74, 0x19, 0x2C, 0x53, 0x49, 0xAB, 0xBC };
        const string cryptoKey =
                "Q3JpcHRvZ3JhZmlhcyBjb20gUmluamRhZWwgLyBBRVM=";
        try
        {
                // Se a string n�o est� vazia, executa a criptografia
                if (!string.IsNullOrEmpty (arg0)) {
                        // Cria instancias de vetores de bytes com as chaves
                        byte[] bKey = Convert.FromBase64String (cryptoKey);
                        byte[] bText = new UTF8Encoding ().GetBytes (arg0);

                        // Instancia a classe de criptografia Rijndael
                        System.Security.Cryptography.Rijndael rijndael = new System.Security.Cryptography.RijndaelManaged ();

                        // Define o tamanho da chave "256 = 8 * 32"
                        // Lembre-se: chaves poss�ves:
                        // 128 (16 caracteres), 192 (24 caracteres) e 256 (32 caracteres)
                        rijndael.KeySize = 256;

                        // Cria o espa�o de mem�ria para guardar o valor criptografado:
                        System.IO.MemoryStream mStream = new System.IO.MemoryStream ();
                        // Instancia o encriptador
                        System.Security.Cryptography.CryptoStream encryptor = new System.Security.Cryptography.CryptoStream (
                                mStream,
                                rijndael.CreateEncryptor (bKey, bIV),
                                System.Security.Cryptography.CryptoStreamMode.Write);

                        // Faz a escrita dos dados criptografados no espa�o de mem�ria
                        encryptor.Write (bText, 0, bText.Length);
                        // Despeja toda a mem�ria.
                        encryptor.FlushFinalBlock ();
                        // Pega o vetor de bytes da mem�ria e gera a string criptografada
                        return Convert.ToBase64String (mStream.ToArray ());
                }
                else{
                        // Se a string for vazia retorna nulo
                        return null;
                }
        }
        catch (Exception ex)
        {
                // Se algum erro ocorrer, dispara a exce��o
                throw new ApplicationException ("Erro ao criptografar", ex);
        }

        /*PROTECTED REGION END*/
}
}
}
