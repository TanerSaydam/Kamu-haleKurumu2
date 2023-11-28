using Microsoft.Win32;

public string ReadRegistryValue(string keyPath, string keyName)
{
	// Registry'den de�er okuma
	try
	{
		using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath))
		{
			if (key != null)
			{
				Object o = key.GetValue(keyName);
				if (o != null)
				{
					// �ifreli veriyi ��zmek i�in kendi �ifre ��zme metodunuzu burada kullan�n
					string decryptedValue = Decrypt(o.ToString());
					return decryptedValue;
				}
			}
		}
	}
	catch (Exception ex)
	{
		// Hata y�netimi
		Console.WriteLine($"An error occurred: {ex.Message}");
	}
	return null;
}

private string Decrypt(string encryptedValue)
{
	// �ifre ��zme i�lemlerinizi burada yap�n
	// Bu �ok basit bir �rnektir, g�venli �ifreleme y�ntemleri kullanmal�s�n�z
	return Encoding.UTF8.GetString(Convert.FromBase64String(encryptedValue));
}