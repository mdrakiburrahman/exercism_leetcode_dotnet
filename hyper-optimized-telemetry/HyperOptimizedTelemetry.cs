using System;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        // Steps:
        // 1. Find out which range the number falls under, cast the number into the appropriate byte array
        // 2. Get number of zero elements in data starting from the right
        // 3. Prepend appropriately in byte[0]
        
        bool signed = false;
        byte[] data = new byte[8]; // Max payload is 8

        switch (reading)
        {
            // long
            case >= -9223372036854775808 when reading <= -2147483649:
                data = BitConverter.GetBytes((long)reading);
                signed = true;
                break;
            // int
            case >= -2147483648 when reading <= -32769:
                data = BitConverter.GetBytes((int)reading);
                signed = true;
                break;
            // short
            case >= -32768 when reading <= -1:
                data = BitConverter.GetBytes((short)reading);
                signed = true;
                break;
            // ushort
            case >= 0 when reading <= 65535:
                data = BitConverter.GetBytes((ushort)reading);
                signed = false;
                break;
            // int
            case >= 65536 when reading <= 2147483647:
                data = BitConverter.GetBytes((int)reading);
                signed = true;
                break;
            // uint
            case >= 2147483648 when reading <= 4294967295:
                data = BitConverter.GetBytes((uint)reading);
                signed = false;
                break;
            // long
            case >= 4294967296 when reading <= 9223372036854775807:
                data = BitConverter.GetBytes((long)reading);
                signed = true;
                break;
            default:
                throw new ArgumentOutOfRangeException();        
        }

        byte[] returnBuffer = new byte[9];

        // Set first position based on signed or unsigned
        if (!signed) // Unsigned
        {
            returnBuffer[0] = (byte)(data.Length);
        } else { // Signed
            returnBuffer[0] = (byte)(256 - data.Length);
        }

        // Copy data into the return buffer
        for (int i = 0; i < data.Length; i++)
        {
            returnBuffer[i + 1] = data[i];
        }

        return returnBuffer;
    }

    public static long FromBuffer(byte[] buffer)
    {
        // BitConverter.To___ converts sign based on casting provided, so we just need to use the prefix to cast it properly
        switch ((int)buffer[0])
        {
            case 2:
                return BitConverter.ToUInt16(buffer, 1);
            case 4:
                return BitConverter.ToUInt32(buffer, 1);
            case 254:
                return BitConverter.ToInt16(buffer, 1);
            case 252:
                return BitConverter.ToInt32(buffer, 1);
            case 248:
                return BitConverter.ToInt64(buffer, 1);
            default:
                return 0;
        }
    }
}
