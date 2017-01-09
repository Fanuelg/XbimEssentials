using System;
using log4net;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Xbim.Common.Enumerations;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using static Xbim.Ifc4.Functions;
// ReSharper disable once CheckNamespace
// ReSharper disable InconsistentNaming
namespace Xbim.Ifc4.GeometricModelResource
{
	public partial class IfcBoxedHalfSpace : IExpressValidatable
	{
		private static readonly ILog Log = LogManager.GetLogger("Xbim.Ifc4.GeometricModelResource.IfcBoxedHalfSpace");

		/// <summary>
		/// Tests the express where-clause specified in param 'clause'
		/// </summary>
		/// <param name="clause">The express clause to test</param>
		/// <returns>true if the clause is satisfied.</returns>
		public bool ValidateClause(Where.IfcBoxedHalfSpace clause) {
			var retVal = false;
			if (clause == Where.IfcBoxedHalfSpace.UnboundedSurface) {
				try {
					retVal = !(TYPEOF(this/* as IfcHalfSpaceSolid*/.BaseSurface).Contains("IFC4.IFCCURVEBOUNDEDPLANE"));
				} catch (Exception ex) {
					Log.Error($"Exception thrown evaluating where-clause 'IfcBoxedHalfSpace.UnboundedSurface' for #{EntityLabel}.", ex);
				}
				return retVal;
			}
			throw new ArgumentException($"Invalid clause specifier: '{clause}'", nameof(clause));
		}

		public IEnumerable<ValidationResult> Validate()
		{
			if (!ValidateClause(Where.IfcBoxedHalfSpace.UnboundedSurface))
				yield return new ValidationResult() { Item = this, IssueSource = "IfcBoxedHalfSpace.UnboundedSurface", IssueType = ValidationFlags.EntityWhereClauses };
		}
	}
}
// ReSharper disable once CheckNamespace
// ReSharper disable InconsistentNaming
namespace Xbim.Ifc4.Where
{
	public class IfcBoxedHalfSpace
	{
		public static readonly IfcBoxedHalfSpace UnboundedSurface = new IfcBoxedHalfSpace();
		protected IfcBoxedHalfSpace() {}
	}
}