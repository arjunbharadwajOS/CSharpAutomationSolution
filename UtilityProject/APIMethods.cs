

namespace UtilityProject
{
    public class APIMethods
    {
        public RestClient client;
        public RestRequest request;
        public RestResponse response;

        public void initialiseAPIClient(string baseURL)
        {
            client = new RestClient(baseURL);
        }

        public void initialiseAPIClient(string baseURL, string relativeURL)
        {
            client = new RestClient(baseURL);
            request = new RestRequest(relativeURL);
        }

        public RestResponse getRequest()
        {
            try
            {
                response = client.ExecuteGet(request);

            }catch(Exception exp)
            {
                Console.WriteLine(exp.Message);
            }

            return response;
        }

        public RestResponse postRequest(string requestData)
        {
            try { 
                request.AddParameter("application/json", requestData, ParameterType.RequestBody);
                request.AddHeader("Authorization", "Bearer my-token");
                request.AddHeader("My-Custom-Header", "foobar");

                response = client.ExecutePost(request);

            }catch(Exception exp)
            {
                Console.WriteLine(exp.Message);
            }

            return response;

        }

        public RestResponse putRequest(string requestData)
        {
            try { 
                request.AddParameter("application/json", requestData, ParameterType.RequestBody);
                request.AddHeader("Authorization", "Bearer my-token");
                request.AddHeader("My-Custom-Header", "foobar");

                response = client.ExecutePut(request);

            }catch(Exception exp)
            {
                Console.WriteLine(exp.Message);
            }

            return response;

        }

        public RestResponse patchRequest(string relativeURL, string requestData)
        {
            try { 
                request = new RestRequest(relativeURL, Method.Patch);
                request.AddParameter("application/json", requestData, ParameterType.RequestBody);
                request.AddHeader("Authorization", "Bearer my-token");
                request.AddHeader("My-Custom-Header", "foobar");

                response = client.ExecutePut(request);

            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }


            return response;

        }

        public RestResponse deleteRequest(string relativeURL)
        {
            try { 
                request = new RestRequest(relativeURL, Method.Delete);
                request.AddHeader("Authorization", "Bearer my-token");
                request.AddHeader("My-Custom-Header", "foobar");
                var response = client.Execute(request);

            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }

            return response;

        }


        public void apitearDown()
        {
            request = null;
            response = null;
            client = null;
        }

    }
}
