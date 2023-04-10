using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.RegularExpressions;

namespace RedeSocial.Domain.Services
{
    public class BlobStorageUpload
    {
        public string UploadBase64Image(string base64Image, string container)
        {
            // Gera um nome randomico para imagem
            var fileName = Guid.NewGuid().ToString() + ".jpg";

            // Limpa o hash enviado
            var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64Image, "");

            // Gera um array de Bytes
            byte[] imageBytes = Convert.FromBase64String(data);

            // Define o BLOB no qual a imagem será armazenada
            var blobClient = new BlobClient("DefaultEndpointsProtocol=https;AccountName=storagesamplescrete;AccountKey=kdy+UEYulhU5yD5jmkDQQT6gnv0/SiaJubqcH5JEogh8pXZxPSfEmS3YHKZk2c7bW/kpz6Agk4iN+AStJCBIlg==;EndpointSuffix=core.windows.net", container, fileName);

            // Envia a imagem
            using (var stream = new MemoryStream(imageBytes))
            {
                blobClient.Upload(stream);
            }

            // Retorna a URL da imagem
            return blobClient.Uri.AbsoluteUri.ToString();
        }


    }
}
