using System;
using System.Threading.Tasks;

public enum GenerationType
{
	pattern,
	numeric,
	character,
	symbol,
	emoticon,
	binary
}

public class RandonGenerateKey
{
	private byte defalt_len = 4;
	private const byte defalt_max_len = 30;

	private char[] symbols = { '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~' };

	private string[] emoticons = {"😀", "🤣", "😅", "😊", "😍", "😗","☺","🤩", "😐", "🙄", 
	"😥", "😯", "😁", "😃", "😆", "😋", "😘", "😙", "🙂", "🤔", "😑", "😏", "😮", "😪", 
	"😂", "😄", "😉", "😎", "🥰", "😚", "🤗", "🤨", "😶", "😣", "🤐", "😫", "🥱", "😴",
	"😌", "😛", "😜", "😝", "🤤", "😒", "😓", "😔", "😕", "🙃", "🤑", "😲","🙁","😖",
	"😞", "😟"};

	private Random randon_value = new Random();

	private string composite_string_key = "";

	public string Generate(GenerationType type, byte len)
	{
		this.defalt_len = len;

		if (len < 4)
			this.defalt_len = 4;
		else if (len > 30)
			this.defalt_len = 30;

		string key = "";

		this.composite_string_key = "";

		switch (type)
		{
			case GenerationType.pattern: key = pattern(); break;

			case GenerationType.numeric: key = numeric(); break;

			case GenerationType.character: key = character(); break;

			case GenerationType.symbol: key = symbol(); break;

			case GenerationType.emoticon: key = emoticon(); break;

			case GenerationType.binary: key = binary(); break;
		}

		return key;
	}

	private string pattern()
	{
		
		const byte start_ascii_pattern = 33;
		const byte end_ascii_pattern = 126;

		for (byte i = 0; i < this.defalt_len; i++)
		{
			this.composite_string_key += Convert.ToChar(this.randon_value.Next(start_ascii_pattern, end_ascii_pattern));
		}

		return this.composite_string_key;
	}

	private string numeric()
	{

		const byte start_ascii_pattern = 48;
		const byte end_ascii_pattern = 57;

		for (byte i = 0; i < this.defalt_len; i++)
		{
			this.composite_string_key += Convert.ToChar(this.randon_value.Next(start_ascii_pattern, end_ascii_pattern));
		}
		
		return this.composite_string_key;
	}

	private string character()
	{
		const byte start_ascii_pattern = 65;
		const byte end_ascii_pattern = 122;

		int value_next = 0;

		
		for (byte i = 0; i < this.defalt_len; i++)
		{
			value_next = this.randon_value.Next(start_ascii_pattern, end_ascii_pattern);

			while (value_next > 90 && value_next < 97)
				value_next = this.randon_value.Next(start_ascii_pattern, end_ascii_pattern);

			this.composite_string_key += Convert.ToChar(value_next);
		}
		

		return this.composite_string_key;
	}

	private string symbol()
	{
		int value = 0;

		for (byte i = 0; i < this.defalt_len; i++)
		{
			value = this.randon_value.Next(0, symbols.Length - 1);

			this.composite_string_key += symbols[value];
		}
		
		return this.composite_string_key;
	}

	private string emoticon()
	{
		int value = 0;

		for (byte i = 0; i < this.defalt_len; i++)
		{
			value = this.randon_value.Next(0, symbols.Length - 1);

			this.composite_string_key += this.emoticons[value];
		}

		return this.composite_string_key;
	}

	private string binary()
	{
		int value = 0;

		for (byte i = 0; i<this.defalt_len; i++)
        {
			value = this.randon_value.Next(0, 2);
			this.composite_string_key += value.ToString();
		}

		return this.composite_string_key;
	}
}
