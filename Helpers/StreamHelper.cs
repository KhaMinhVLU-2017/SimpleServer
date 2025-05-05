namespace simpleServer.Helpers
{
    public class StreamHelper
    {
        public static byte[] Combine(params byte[][] arrays)
        {
            byte[] rv = new byte[arrays.Sum(a => a.Length)];
            int offset = 0;
            foreach (byte[] array in arrays)
            {
                System.Buffer.BlockCopy(array, 0, rv, offset, array.Length);
                offset += array.Length;
            }
            return rv;
        }

        // TODO Need read current binaries stream of streamreader.
        public static byte[] ConvertBianaries(StreamReader stream)
        {
            byte[] bytes = null;
            using (MemoryStream ms = new MemoryStream())
            {
                int b = 0;
                while ((b = stream.Read()) != -1)
                    ms.WriteByte((byte)b);
                bytes = ms.ToArray();
            }
            return bytes;
        }
    }
}