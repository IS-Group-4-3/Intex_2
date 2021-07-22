using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Intex_2.Services
{
    public class S3Service : IS3Service
    {
        private readonly AmazonS3Client s3Client;
        private const string BUCKET_NAME = "arn:aws:s3:us-east-2:306425856722:accesspoint/el-gamous";// get the amazon info
        private const string FOLDER_NAME = "uploads";
        private const double DURATION = 24;
        public S3Service()
        {
            //s3Client = new AmazonS3Client(RegionEndpoint.USEast2);
            var amazonS3Config = new AmazonS3Config
            {
                RegionEndpoint = RegionEndpoint.USEast2
            };
            var credentials = new BasicAWSCredentials("", "");
            AmazonS3Client client = new AmazonS3Client(credentials, amazonS3Config);
            s3Client = client;
        }
        private string GeneratePreSignedURL(string objectKey)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = BUCKET_NAME,
                Key = objectKey,
                Verb = HttpVerb.GET,
                Expires = DateTime.UtcNow.AddHours(DURATION)
            };

            string url = s3Client.GetPreSignedURL(request);
            return url;
        }
        public async Task<string> AddItem(IFormFile file, string readerName)
        {
            string fileName = file.FileName;
            string objectKey = $"{FOLDER_NAME}/{fileName}";
            //string objectKey = $"{FOLDER_NAME}/{readerName}/{fileName}";

            using (Stream fileToUpload = file.OpenReadStream())
            {
                var putObjectRequest = new PutObjectRequest();
                putObjectRequest.BucketName = BUCKET_NAME;
                putObjectRequest.Key = objectKey;
                putObjectRequest.InputStream = fileToUpload;
                putObjectRequest.ContentType = file.ContentType;

                var response = await s3Client.PutObjectAsync(putObjectRequest);

                return GeneratePreSignedURL(objectKey);
            }
        }

    }
}
