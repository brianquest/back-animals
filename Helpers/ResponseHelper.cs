using animals.DTOs;

namespace animals.Helpers
{
    public class ResponseHelper
    {
        public static Response OkResponse(object? data, string message = "")
        {
            var response = new Response();

            response.Status = true;
            if (data != null) response.Data = data;
            response.Message = message;

            return response;
        }

        public static Response BadResponse(Exception ex)
        {
            var response = new Response();

            response.Status = false;
            response.Message = ex.Message;

            return response;
        }
    }
}
