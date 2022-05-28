/*
 * Created by SharpDevelop.
 * User: Martin
 * Date: 26/05/2022
 * Time: 2:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace IdentificableNS
{
	public class Identificable
	{
		protected string id;
		
		public string Id {
			set{this.id=value;}
			get{return this.id;}
		}
	}
}
