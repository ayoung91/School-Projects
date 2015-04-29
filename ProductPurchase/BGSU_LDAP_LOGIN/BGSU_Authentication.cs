using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.Security.Cryptography;
using System.IO;

namespace BGSU_LDAP_LOGIN
{
    public class BGSU_Authentication
    {

        private string domainName, ldapPath, username, password, _hash_password;
		private string _FirstName, _LastName, _FullName, _Email, _AthenticationType;
		bool password_supplied = false;

		AuthenticationTypes at = AuthenticationTypes.Signing | AuthenticationTypes.Sealing | AuthenticationTypes.Secure;

		public BGSU_Authentication(string domain, string ldap)
		{
			domainName = domain;
			ldapPath = ldap;
			username = "";
			password = "";
		}


        public BGSU_Authentication(string domain, string ldap, string user, string pwd)
		{
			domainName = domain;
			ldapPath = ldap;
			username = user;
			password = pwd;
		}


		public bool IsLoginValid()
		{
			bool isValid = false;
			password_supplied = false;
			//return true;

			if (password != "")
			{
				this.password_supplied = true;
				try
				{

					string fullUsername = string.Format( @"{0}\{1}", domainName, username );
					// Fulluser name: e.g. bgsu\jsmith

					DirectoryEntry entry = new DirectoryEntry( ldapPath, fullUsername, password, at );
					DirectorySearcher searcher = new DirectorySearcher( entry );
					searcher.Filter = string.Format( "(samAccountName={0})", username );


					SearchResult result = searcher.FindOne();
					isValid = ( null != result );

					SearchResultCollection AllResults = searcher.FindAll();

					string sb = "";
					foreach (SearchResult myResults in AllResults)
					{
						ResultPropertyCollection propcoll=myResults.Properties;
						foreach(string key in propcoll.PropertyNames) 									
						{

							foreach(object values in propcoll[key])
							{
							//	MessageBox.Show(values.ToString());
								switch (key)
								{
									case "displayname":
										_FullName = values.ToString();							
			
										sb = key.ToString() + " = " +  values.ToString();
										break;
									
									case "givenname":
										_FirstName = values.ToString();
										sb = key.ToString() + " = " +  values.ToString();
										break;
									
									case "sn":
										_LastName = values.ToString();
										sb = key.ToString() + " = " +  values.ToString();
										break;

									case "userprincipalname":
										this._Email = values.ToString();
										sb = key.ToString() + " = " +  values.ToString();
										break;

									default:
										sb = key.ToString() + " = " +  values.ToString();
										//										MessageBox.Show(sb);
										break;
								}
							}

						}
					}

					this._AthenticationType = result.GetDirectoryEntry().AuthenticationType.ToString();

				}
				catch
				{
			
					/* Replace this code with logging, etc. */
				}
			}

			return isValid;
		}



	
		public string UserName
		{
			get
			{
				return this.username;
			}
			set
			{
				this.username = value;
			}
		}
	

		public string Password
		{

			set
			{
				password = value;
			}
		}

		
		public bool Password_Supplied
		{

			get
			{
				return this.password_supplied;
			}
		}

		public string FullName
		{
			get
			{
				return this._FullName;
			}
		}
		public string LastName
		{
			get
			{
				return this._LastName;
			}
		}

		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
		}

		public string Email
		{
			get
			{
				return this._Email;
			}

		}

		public string AuthenticationType
		{
			get
			{
				return this._AthenticationType;
			}
		}

		public string hash_password
		{
			get
			{
				return this._hash_password;
			}
		}





    }
}
