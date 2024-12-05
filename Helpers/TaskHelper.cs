namespace simpleServer.Helpers
{
    public static class TaskHelper
    {
        public static async Task<T> GetResultFromTaskAsync<T>(this object taskObj)
        {
            var task = (Task)taskObj;
            await task;
            var result = (T)taskObj.GetType().GetProperty("Result").GetValue(taskObj, null);
            return result;
        }
    }
}