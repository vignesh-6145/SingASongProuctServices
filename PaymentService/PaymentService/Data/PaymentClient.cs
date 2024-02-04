using DataService.Data;
using DataService.Models;
using Newtonsoft.Json.Linq;
using System.Net;

namespace PaymentService.Data
{
    public class PaymentClient
    {
        APIClient client;
        public PaymentClient()
        {
            client  = new APIClient("https://localhost:7197/");
        }
        public Payment GetRecord(int PaymentID)
        {
            try
            {
                string GetRecordURL = $"api/Payment/GetRecord/{PaymentID}";
                var ResponseString = client.MakeGetAPICall(GetRecordURL);
                return DataClient.ConverToPayment(ResponseString);
            }catch(Exception ex) { 
                Console.WriteLine($"Unable to Retrieve Payment Record : {PaymentID}");
                Console.WriteLine(ex.Message);
                return null;
            }



        }
        public IEnumerable<Payment> GetPaymentHistory()
        {
            string GETpaymentHistoryURL = "api/Payment/GetAllRecords";
            var ResponseStr = client.MakeGetAPICall(GETpaymentHistoryURL);
            List<Payment> history = new List<Payment>();
            JArray arr = JArray.Parse(ResponseStr);
            foreach(var record in arr)
            {
                history.Add(DataClient.ConverToPayment(record));
            }
            return history;
        }
        public HttpStatusCode AddPaymentRecord(Payment payment)
        {
            string PostPaymentRecordAPI = "api/Payment/AddPaymentRecord";
            return client.MakePostCall(PostPaymentRecordAPI, payment);


        }

    }
}
