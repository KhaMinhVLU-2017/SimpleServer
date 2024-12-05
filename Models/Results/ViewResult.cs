using simpleServer.Helpers;
using simpleServer.Exceptions;
using simpleServer.Https.Models;

namespace simpleServer.Models.Results
{
    public class ViewResult : BaseResult
    {
        public override async Task RunAsync(HttpContext context)
        {
            string actionTxt = context.Request.Path.GetActionFromPath();
            string viewPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Views");
            string viewFileName = $"{actionTxt}.cshtml";
            string filePath = Path.Combine(viewPath, viewFileName);
            bool hasFile = Directory.GetFiles(viewPath).Any(f => f.Equals(filePath, StringComparison.InvariantCultureIgnoreCase));
            if (!hasFile) throw new NotFoundException();

            string fileName = Directory.GetFiles(viewPath).First(f => f.Equals(filePath, StringComparison.InvariantCultureIgnoreCase));
            string htmlRaw = await File.ReadAllTextAsync(filePath);

            var htmlResult = ResultFactory.CreateHtml(htmlRaw);
            await htmlResult.RunAsync(context);
        }
    }
}