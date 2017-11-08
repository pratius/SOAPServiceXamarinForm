using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace WebServiceParsing
{
	[XmlRoot(ElementName = "ValidateLogin")]
	public class ValidateLogin
	{
		[XmlAttribute(AttributeName = "validateLogin")]
		public string ValidateLogins { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "CreateAccount")]
	public class CreateAccount
	{
		[XmlAttribute(AttributeName = "createAccount")]
		public string CreateAccounts { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "UserPassword")]
	public class UserPassword
	{
		[XmlAttribute(AttributeName = "password")]
		public string Password { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "UserName")]
	public class UserName
	{
		[XmlAttribute(AttributeName = "userName")]
		public string UserNames { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "Connfiguration")]
	public class Connfiguration
	{
		[XmlElement(ElementName = "ValidateLogin")]
		public ValidateLogin ValidateLogin { get; set; }
		[XmlElement(ElementName = "CreateAccount")]
		public CreateAccount CreateAccount { get; set; }
		[XmlElement(ElementName = "UserPassword")]
		public UserPassword UserPassword { get; set; }
		[XmlElement(ElementName = "UserName")]
		public UserName UserName { get; set; }
		[XmlAttribute(AttributeName = "id")]
		public string Id { get; set; }
	}

	[XmlRoot(ElementName = "Configurations")]
	public class Configurations
	{
		[XmlElement(ElementName = "Connfiguration")]
		public List<Connfiguration> Connfiguration { get; set; }
	}
}
