namespace Demo.Microservices.Services.BatchJob.Service
{
   public class NewsVerificationService
    {
        public void ApproveNews()
        {
            //here based on some rules pipeline, it will either accept or reject the new
            //if accept, it will call an endpoint which will then push the news to db as well as solr and then push an approve email to the queue back
            //if reject, it will send a rejection email to the sender

        }

       
    }
}
