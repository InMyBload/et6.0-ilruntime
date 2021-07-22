using UnityEngine.Networking;

namespace ETModel 
{
    public class AcceptAllCertificate : CertificateHandler
    {
        protected override bool ValidateCertificate(byte[] certificateData)
        {
            return true;
        }
    }
}
