﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pardis.Product.BLL.ViewModel
{
    public class Person
    {
        public Person()
        {
            Accounts = new HashSet<Account>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Fname { get; set; }

        [StringLength(256)]
        public string Lname { get; set; }

        [StringLength(20)]
        public string NationalCode { get; set; }

        [StringLength(64)]
        public string SabtCode { get; set; }

        public short TypeID { get; set; }

        public bool? IsDeleted { get; set; }

        [StringLength(64)]
        public string EconomicCode { get; set; }

        public long? provinceID { get; set; }

        public long? CityID { get; set; }

        [StringLength(2048)]
        public string Address { get; set; }

        [StringLength(16)]
        public string ZipCode { get; set; }

        [StringLength(16)]
        public string Phone { get; set; }

        [StringLength(512)]
        public string Job { get; set; }

        public DateTime? Birthday { get; set; }

        [StringLength(16)]
        public string fax { get; set; }

        [StringLength(128)]
        public string Email { get; set; }

        public int? Education { get; set; }

        [StringLength(128)]
        public string FatherName { get; set; }

        public DateTime? SabtDate { get; set; }

        [StringLength(11)]
        public string Mobile { get; set; }

        [StringLength(256)]
        public string Site { get; set; }

        public short? MaritalStatus { get; set; }

        public bool? Sex { get; set; }

        [StringLength(256)]
        public string Study { get; set; }

        public short? LegalTypeID { get; set; }

        public short? TypeGovernmentCompanyID { get; set; }

        public short? GovernmentSharePercentage { get; set; }

        [StringLength(512)]
        public string GroupType { get; set; }

        public bool? TransferList { get; set; }

        [StringLength(512)]
        public string LegalDocumentation { get; set; }

        public byte[] Image { get; set; }

        /// <summary>
        /// Just For Test
        /// </summary>
        public string ImageName { get; set; }

        public short? Religion { get; set; }

        public short? Gilder { get; set; }

        public short? Nationality { get; set; }

        public bool? OrganizationEmployee { get; set; }

        public byte? RelationshipTypeId { get; set; }

        public string FieldActivity { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }

        public virtual string FullName => $"{Fname} {Lname}";
    }
}
