/***************************************************************************
 * 3DES ( Three DES o Triple DES )
 * Antes de ser quebrado el DES, ya se trabajaba en un nuevo algoritmo basado en el anterior. 
 * Este funciona aplicando tres veces el proceso con tres llaves diferentes de 56 bits. 
 * La importancia de esto es que si alguien puede descifrar una llave, es casi imposible poder descifrar las tres y utilizarlas en el orden adecuado. 
 * Hoy en día es uno de los algoritmos simétricos más seguros.
 * 
 * 
 * IV (Vector de inicialización)
 * Esta cadena se utiliza para empezar cada proceso de encriptación. 
 * Un error común es utilizar la misma cadena de inicialización en todas las encriptaciones. 
 * En ese caso, el resultado de las encriptaciones es similar, pudiendo ahorrarle mucho trabajo a un hacker en el desciframiento de los datos. 
 * Tiene 16 bytes de largo. Puedes encontrar más información acerca de IV en http://www.atrevido.net/blog/PermaLink.aspx?guid=6136ce81-9fa1-4995-bb3e-15bc5f1f5899 .
 * 
 * Key (llave)
 * Esta es la principal información para encriptar y desencriptar en los algoritmos simétricos. 
 * Toda la seguridad del sistema depende de dónde esté esta llave, cómo esté compuesta y quién tiene acceso. 
 * El largo de las llaves depende del algoritmo. 
 * Al final del documento se darán algunas recomendaciones para el almacenamiento, generación y rotación de llaves.
 *  
 * 
 * 
 *Fuente: (Lectura recomendada http://msdn.microsoft.com/es-es/library/bb972216.aspx) 
 * *****************************************************************************/

using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Olimpiadas.CrossCutting.Helper.Security
{
    /// <summary>
    /// Clase que proporciona servicios criptográficos de texto, entre los que se incluyen la codificación y descodificación segura de los datos y otras muchas operaciones como.
    /// </summary>
    public class Cryptography
    {
        #region PROPIEDADES NUEVAS
        /// <summary>
        /// La clave secreta que se va a utilizar para el algoritmo simétrico. 
        /// </summary>
        private byte[] Key
        {
            get { return new byte[] { 21, 16, 2, 10, 20, 8, 9, 7, 24, 29, 1, 23, 13, 3, 17, 15, 14, 1, 19, 6, 18, 5, 12, 20 }; }
        }

        /// <summary>
        /// El vector de inicialización que se va a utilizar para el algoritmo simétrico. 
        /// </summary>
        private byte[] IV
        {
            get { return new byte[] { 178, 109, 219, 26, 69, 200, 65, 68 }; }
        }        

        #endregion

        #region PROCEDIMIENTOS NUEVOS
        /// <summary>
        /// Encripta una cadena de texto usando el algoritmo TripleDESCryptoServiceProvider.
        /// </summary>
        /// <param name="strData">Texto que se va a encriptar.</param>
        /// <returns></returns>
        public byte[] Encrypt(string strData)
        {
            var objCryptoService = new TripleDESCryptoServiceProvider();
            var objMemoryStream = new MemoryStream();

            var objCryptoStream = new CryptoStream(objMemoryStream, new TripleDESCryptoServiceProvider().CreateEncryptor(Key, IV), CryptoStreamMode.Write);
            byte[] toEncrypt = new ASCIIEncoding().GetBytes(strData);

            objCryptoStream.Write(toEncrypt, 0, toEncrypt.Length);
            objCryptoStream.FlushFinalBlock();
            byte[] rect = objMemoryStream.ToArray();

            objMemoryStream.Close();
            objCryptoStream.Close();            
            objCryptoService.Clear();

            return rect;
        }

        /// <summary>
        /// Encripta la cadeba
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        public string EncryptToString(string strData)
        {
            byte[] rect = Encrypt(strData);
            //System.Text.Encoding encoding = new UTF7Encoding();
            //var encodedBytes = encoding.GetString(rect);

            //return encodedBytes;

            var cookieString = new StringBuilder();
            foreach (byte item in rect)
            {
                cookieString.Append(item);
                cookieString.Append(",");
            }
            cookieString = cookieString.Remove(cookieString.Length - 1, 1);
            return cookieString.ToString();
        }                

        /// <summary>
        /// Descencripta una secuencia de bytes usando el algoritmo TripleDESCryptoServiceProvider.
        /// </summary>
        /// <param name="bytInput">Secuencia de bytes que se va a descencriptar.</param>
        /// <returns>Cadena descencriptada</returns>
        public string Decrypt(byte[] bytInput)
        {
            var objMemoryStream = new MemoryStream(bytInput);
            var objCryptoStream = new CryptoStream(objMemoryStream, new TripleDESCryptoServiceProvider().CreateDecryptor(Key, IV), CryptoStreamMode.Read);
            var fromEncrypt = new byte[bytInput.Length];

            objCryptoStream.Read(fromEncrypt, 0, fromEncrypt.Length);
            objMemoryStream.Close();
            objCryptoStream.Close();

            return new ASCIIEncoding().GetString(fromEncrypt).TrimEnd(new[] { '\0' });
        }

        /// <summary>
        /// Descencripta una secuencia de bytes usando el algoritmo TripleDESCryptoServiceProvider
        /// </summary>
        /// <param name="inputString">Cadena que se va a descencriptar, el cual debe estra como texto </param>
        /// <returns>Cadena descencriptada</returns>
        public string DecryptString(string inputString)
        {
            if (string.IsNullOrEmpty(inputString)) return string.Empty;

            //var key = System.Text.Encoding.UTF7.GetBytes(inputString);
            //return Decrypt(key);

            var inputSplit = inputString.Split(',');
            var inputBytes = new byte[inputSplit.Length];

            int index = 0;
            foreach (string item in inputSplit)
            {
                inputBytes[index] = byte.Parse(item);
                index += 1;
            }

            return Decrypt(inputBytes);
        }

        /// <summary>
        /// Genera una contraseña aleatoria.
        /// </summary>
        /// <param name="bytCantidadCarecteres">Cantidad de caracteres que debe tener la contraseña, el máximo es 10.</param>
        /// <returns></returns>
        public static string RandomPassword(byte bytCantidadCarecteres = 6)
        {
            if (bytCantidadCarecteres > 10) bytCantidadCarecteres = 10;
            var strGuid = System.Guid.NewGuid().ToString().ToUpper();
            var newGuid= strGuid.Replace("-", "");
            return newGuid.Substring(0, bytCantidadCarecteres);
        }

        #endregion
    }
}