using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDMX2TSConsole
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2007/06/edmx")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/06/edmx", IsNullable = false)]
    public partial class Edmx
    {

        private EdmxDataServices dataServicesField;

        private decimal versionField;

        /// <remarks/>
        public EdmxDataServices DataServices
        {
            get
            {
                return this.dataServicesField;
            }
            set
            {
                this.dataServicesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal Version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2007/06/edmx")]
    public partial class EdmxDataServices
    {

        private Schema schemaField;

        private decimal dataServiceVersionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.microsoft.com/ado/2008/09/edm")]
        public Schema Schema
        {
            get
            {
                return this.schemaField;
            }
            set
            {
                this.schemaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
        public decimal DataServiceVersion
        {
            get
            {
                return this.dataServiceVersionField;
            }
            set
            {
                this.dataServiceVersionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2008/09/edm")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.microsoft.com/ado/2008/09/edm", IsNullable = false)]
    public partial class Schema
    {

        private Annotation annotationField;

        private SchemaEntityType[] entityTypeField;

        private SchemaAssociation[] associationField;

        private SchemaEntityContainer entityContainerField;

        private link[] linkField;

        private string namespaceField;

        private string langField;

        private byte schemaversionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://docs.oasis-open.org/odata/ns/edm")]
        public Annotation Annotation
        {
            get
            {
                return this.annotationField;
            }
            set
            {
                this.annotationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EntityType")]
        public SchemaEntityType[] EntityType
        {
            get
            {
                return this.entityTypeField;
            }
            set
            {
                this.entityTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Association")]
        public SchemaAssociation[] Association
        {
            get
            {
                return this.associationField;
            }
            set
            {
                this.associationField = value;
            }
        }

        /// <remarks/>
        public SchemaEntityContainer EntityContainer
        {
            get
            {
                return this.entityContainerField;
            }
            set
            {
                this.entityContainerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("link", Namespace = "http://www.w3.org/2005/Atom")]
        public link[] link
        {
            get
            {
                return this.linkField;
            }
            set
            {
                this.linkField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Namespace
        {
            get
            {
                return this.namespaceField;
            }
            set
            {
                this.namespaceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("schema-version", Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.sap.com/Protocols/SAPData")]
        public byte schemaversion
        {
            get
            {
                return this.schemaversionField;
            }
            set
            {
                this.schemaversionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://docs.oasis-open.org/odata/ns/edm")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://docs.oasis-open.org/odata/ns/edm", IsNullable = false)]
    public partial class Annotation
    {

        private string termField;

        private string stringField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Term
        {
            get
            {
                return this.termField;
            }
            set
            {
                this.termField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string String
        {
            get
            {
                return this.stringField;
            }
            set
            {
                this.stringField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2008/09/edm")]
    public partial class SchemaEntityType
    {

        private SchemaEntityTypePropertyRef[] keyField;

        private SchemaEntityTypeProperty[] propertyField;

        private SchemaEntityTypeNavigationProperty[] navigationPropertyField;

        private string nameField;

        private byte contentversionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("PropertyRef", IsNullable = false)]
        public SchemaEntityTypePropertyRef[] Key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Property")]
        public SchemaEntityTypeProperty[] Property
        {
            get
            {
                return this.propertyField;
            }
            set
            {
                this.propertyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NavigationProperty")]
        public SchemaEntityTypeNavigationProperty[] NavigationProperty
        {
            get
            {
                return this.navigationPropertyField;
            }
            set
            {
                this.navigationPropertyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("content-version", Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.sap.com/Protocols/SAPData")]
        public byte contentversion
        {
            get
            {
                return this.contentversionField;
            }
            set
            {
                this.contentversionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2008/09/edm")]
    public partial class SchemaEntityTypePropertyRef
    {

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2008/09/edm")]
    public partial class SchemaEntityTypeProperty
    {

        private string nameField;

        private string typeField;

        private bool nullableField;

        private byte maxLengthField;

        private bool maxLengthFieldSpecified;

        private bool unicodeField;

        private string labelField;

        private bool creatableField;

        private bool updatableField;

        private bool sortableField;

        private bool filterableField;

        private byte precisionField;

        private bool precisionFieldSpecified;

        private byte scaleField;

        private bool scaleFieldSpecified;

        private string unitField;

        private string semanticsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Nullable
        {
            get
            {
                return this.nullableField;
            }
            set
            {
                this.nullableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte MaxLength
        {
            get
            {
                return this.maxLengthField;
            }
            set
            {
                this.maxLengthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MaxLengthSpecified
        {
            get
            {
                return this.maxLengthFieldSpecified;
            }
            set
            {
                this.maxLengthFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.sap.com/Protocols/SAPData")]
        public bool unicode
        {
            get
            {
                return this.unicodeField;
            }
            set
            {
                this.unicodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.sap.com/Protocols/SAPData")]
        public string label
        {
            get
            {
                return this.labelField;
            }
            set
            {
                this.labelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.sap.com/Protocols/SAPData")]
        public bool creatable
        {
            get
            {
                return this.creatableField;
            }
            set
            {
                this.creatableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.sap.com/Protocols/SAPData")]
        public bool updatable
        {
            get
            {
                return this.updatableField;
            }
            set
            {
                this.updatableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.sap.com/Protocols/SAPData")]
        public bool sortable
        {
            get
            {
                return this.sortableField;
            }
            set
            {
                this.sortableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.sap.com/Protocols/SAPData")]
        public bool filterable
        {
            get
            {
                return this.filterableField;
            }
            set
            {
                this.filterableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Precision
        {
            get
            {
                return this.precisionField;
            }
            set
            {
                this.precisionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PrecisionSpecified
        {
            get
            {
                return this.precisionFieldSpecified;
            }
            set
            {
                this.precisionFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Scale
        {
            get
            {
                return this.scaleField;
            }
            set
            {
                this.scaleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ScaleSpecified
        {
            get
            {
                return this.scaleFieldSpecified;
            }
            set
            {
                this.scaleFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.sap.com/Protocols/SAPData")]
        public string unit
        {
            get
            {
                return this.unitField;
            }
            set
            {
                this.unitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.sap.com/Protocols/SAPData")]
        public string semantics
        {
            get
            {
                return this.semanticsField;
            }
            set
            {
                this.semanticsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2008/09/edm")]
    public partial class SchemaEntityTypeNavigationProperty
    {

        private string nameField;

        private string relationshipField;

        private string fromRoleField;

        private string toRoleField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Relationship
        {
            get
            {
                return this.relationshipField;
            }
            set
            {
                this.relationshipField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FromRole
        {
            get
            {
                return this.fromRoleField;
            }
            set
            {
                this.fromRoleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ToRole
        {
            get
            {
                return this.toRoleField;
            }
            set
            {
                this.toRoleField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2008/09/edm")]
    public partial class SchemaAssociation
    {

        private SchemaAssociationEnd[] endField;

        private SchemaAssociationReferentialConstraint referentialConstraintField;

        private string nameField;

        private byte contentversionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("End")]
        public SchemaAssociationEnd[] End
        {
            get
            {
                return this.endField;
            }
            set
            {
                this.endField = value;
            }
        }

        /// <remarks/>
        public SchemaAssociationReferentialConstraint ReferentialConstraint
        {
            get
            {
                return this.referentialConstraintField;
            }
            set
            {
                this.referentialConstraintField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("content-version", Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.sap.com/Protocols/SAPData")]
        public byte contentversion
        {
            get
            {
                return this.contentversionField;
            }
            set
            {
                this.contentversionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2008/09/edm")]
    public partial class SchemaAssociationEnd
    {

        private string typeField;

        private string multiplicityField;

        private string roleField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Multiplicity
        {
            get
            {
                return this.multiplicityField;
            }
            set
            {
                this.multiplicityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Role
        {
            get
            {
                return this.roleField;
            }
            set
            {
                this.roleField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2008/09/edm")]
    public partial class SchemaAssociationReferentialConstraint
    {

        private SchemaAssociationReferentialConstraintPrincipal principalField;

        private SchemaAssociationReferentialConstraintDependent dependentField;

        /// <remarks/>
        public SchemaAssociationReferentialConstraintPrincipal Principal
        {
            get
            {
                return this.principalField;
            }
            set
            {
                this.principalField = value;
            }
        }

        /// <remarks/>
        public SchemaAssociationReferentialConstraintDependent Dependent
        {
            get
            {
                return this.dependentField;
            }
            set
            {
                this.dependentField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2008/09/edm")]
    public partial class SchemaAssociationReferentialConstraintPrincipal
    {

        private SchemaAssociationReferentialConstraintPrincipalPropertyRef propertyRefField;

        private string roleField;

        /// <remarks/>
        public SchemaAssociationReferentialConstraintPrincipalPropertyRef PropertyRef
        {
            get
            {
                return this.propertyRefField;
            }
            set
            {
                this.propertyRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Role
        {
            get
            {
                return this.roleField;
            }
            set
            {
                this.roleField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2008/09/edm")]
    public partial class SchemaAssociationReferentialConstraintPrincipalPropertyRef
    {

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2008/09/edm")]
    public partial class SchemaAssociationReferentialConstraintDependent
    {

        private SchemaAssociationReferentialConstraintDependentPropertyRef propertyRefField;

        private string roleField;

        /// <remarks/>
        public SchemaAssociationReferentialConstraintDependentPropertyRef PropertyRef
        {
            get
            {
                return this.propertyRefField;
            }
            set
            {
                this.propertyRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Role
        {
            get
            {
                return this.roleField;
            }
            set
            {
                this.roleField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2008/09/edm")]
    public partial class SchemaAssociationReferentialConstraintDependentPropertyRef
    {

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2008/09/edm")]
    public partial class SchemaEntityContainer
    {

        private SchemaEntityContainerEntitySet[] entitySetField;

        private SchemaEntityContainerAssociationSet[] associationSetField;

        private string nameField;

        private bool isDefaultEntityContainerField;

        private string supportedformatsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("EntitySet")]
        public SchemaEntityContainerEntitySet[] EntitySet
        {
            get
            {
                return this.entitySetField;
            }
            set
            {
                this.entitySetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AssociationSet")]
        public SchemaEntityContainerAssociationSet[] AssociationSet
        {
            get
            {
                return this.associationSetField;
            }
            set
            {
                this.associationSetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
        public bool IsDefaultEntityContainer
        {
            get
            {
                return this.isDefaultEntityContainerField;
            }
            set
            {
                this.isDefaultEntityContainerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("supported-formats", Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.sap.com/Protocols/SAPData")]
        public string supportedformats
        {
            get
            {
                return this.supportedformatsField;
            }
            set
            {
                this.supportedformatsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2008/09/edm")]
    public partial class SchemaEntityContainerEntitySet
    {

        private string nameField;

        private string entityTypeField;

        private bool creatableField;

        private bool updatableField;

        private bool deletableField;

        private bool pageableField;

        private byte contentversionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string EntityType
        {
            get
            {
                return this.entityTypeField;
            }
            set
            {
                this.entityTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.sap.com/Protocols/SAPData")]
        public bool creatable
        {
            get
            {
                return this.creatableField;
            }
            set
            {
                this.creatableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.sap.com/Protocols/SAPData")]
        public bool updatable
        {
            get
            {
                return this.updatableField;
            }
            set
            {
                this.updatableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.sap.com/Protocols/SAPData")]
        public bool deletable
        {
            get
            {
                return this.deletableField;
            }
            set
            {
                this.deletableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.sap.com/Protocols/SAPData")]
        public bool pageable
        {
            get
            {
                return this.pageableField;
            }
            set
            {
                this.pageableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("content-version", Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.sap.com/Protocols/SAPData")]
        public byte contentversion
        {
            get
            {
                return this.contentversionField;
            }
            set
            {
                this.contentversionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2008/09/edm")]
    public partial class SchemaEntityContainerAssociationSet
    {

        private SchemaEntityContainerAssociationSetEnd[] endField;

        private string nameField;

        private string associationField;

        private bool creatableField;

        private bool updatableField;

        private bool deletableField;

        private byte contentversionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("End")]
        public SchemaEntityContainerAssociationSetEnd[] End
        {
            get
            {
                return this.endField;
            }
            set
            {
                this.endField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Association
        {
            get
            {
                return this.associationField;
            }
            set
            {
                this.associationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.sap.com/Protocols/SAPData")]
        public bool creatable
        {
            get
            {
                return this.creatableField;
            }
            set
            {
                this.creatableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.sap.com/Protocols/SAPData")]
        public bool updatable
        {
            get
            {
                return this.updatableField;
            }
            set
            {
                this.updatableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.sap.com/Protocols/SAPData")]
        public bool deletable
        {
            get
            {
                return this.deletableField;
            }
            set
            {
                this.deletableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("content-version", Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.sap.com/Protocols/SAPData")]
        public byte contentversion
        {
            get
            {
                return this.contentversionField;
            }
            set
            {
                this.contentversionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2008/09/edm")]
    public partial class SchemaEntityContainerAssociationSetEnd
    {

        private string entitySetField;

        private string roleField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string EntitySet
        {
            get
            {
                return this.entitySetField;
            }
            set
            {
                this.entitySetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Role
        {
            get
            {
                return this.roleField;
            }
            set
            {
                this.roleField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2005/Atom")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.w3.org/2005/Atom", IsNullable = false)]
    public partial class link
    {

        private string relField;

        private string hrefField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string rel
        {
            get
            {
                return this.relField;
            }
            set
            {
                this.relField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string href
        {
            get
            {
                return this.hrefField;
            }
            set
            {
                this.hrefField = value;
            }
        }
    }


}
