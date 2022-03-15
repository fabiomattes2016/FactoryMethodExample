using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethodExample.Responses.JsonPlaceHolder
{
    public class PostResponse
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }

        public override string ToString()
        {
            return string.Format($"userId: {userId}\nid: {id}\ntitle: {title}\nbody: {body}");
        }
    }
}
