namespace simpleServer.Models.Results
{
    public static class ResultFactory
    {
        public static IResult CreateJson(object json)
        {
            return new JsonResult(json);
        }

        public static IResult CreateHtml(string html)
        {
            return new HtmlResult(html);
        }

        public static IResult CreateView() => new ViewResult();
    }
}