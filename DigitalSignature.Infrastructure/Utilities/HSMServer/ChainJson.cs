﻿using Org.BouncyCastle.X509;
using System;


namespace Digital.Infrastructure.Utilities.HSMServer
{
    public class ChainJson
    {
        public string sub { get; set; }
        public string end { get; set; }
        public string root { get; set; }
        public X509Certificate[] toArray()
        {
            X509Certificate[] rs = new X509Certificate[3];
            rs[0] = new Org.BouncyCastle.X509.X509CertificateParser().ReadCertificate(Convert.FromBase64String(end));
            rs[1] = new Org.BouncyCastle.X509.X509CertificateParser().ReadCertificate(Convert.FromBase64String(sub));
            rs[2] = new Org.BouncyCastle.X509.X509CertificateParser().ReadCertificate(Convert.FromBase64String(root));
            return rs;
        }
    }
}