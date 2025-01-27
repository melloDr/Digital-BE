﻿using Newtonsoft.Json;

namespace Digital.Infrastructure.Utilities.HSMServer
{
    public class ByteSigner: IByteSigner, IDisposable
    {
        private string? appid;
        private string? secret;
        private string? region;
        private readonly SignClient signClient;
        private bool _disposed;

        public ByteSigner(string appid, string secret, string region)
        {
            this.appid = appid;
            this.secret = secret;
            this.region = region;
            this.signClient = new SignClient(appid, secret, "sign",region);
        }
        public ByteSigner(SignClient? client)
        {
            this.signClient = client!;
        }

        

        public byte[] Sign(byte[] input)
        {
            var binData = new
            {
                payload = Convert.ToBase64String(input),
                alg = "SHA256"
            };
            string binDataJson = JsonConvert.SerializeObject(binData);
            var responseString = signClient.UploadString("/api/v2/bin/sign/base64", "POST", binDataJson);
            var dataSigned = JsonConvert.DeserializeObject<ApiResp>(responseString);
            if (dataSigned!.status == 0)
            {
                var bytesout = Convert.FromBase64String(dataSigned!.obj.ToString()!);
                return bytesout;
            }

            return null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes object
        /// </summary>
        /// <param name="disposing">Flag indicating whether managed resources should be disposed</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                // Dispose managed objects
                if (disposing)
                {
                    signClient.Dispose();
                }

                // Dispose unmanaged objects

                _disposed = true;
            }
        }
    }
}
