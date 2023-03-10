#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CONCESIONARIO_PROYECTO
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Concesionario")]
	public partial class ConcesionarioRepositoryDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    partial void InsertMarcas(Marcas instance);
    partial void UpdateMarcas(Marcas instance);
    partial void DeleteMarcas(Marcas instance);
    partial void InsertModelos(Modelos instance);
    partial void UpdateModelos(Modelos instance);
    partial void DeleteModelos(Modelos instance);
    partial void InsertVehiculos(Vehiculos instance);
    partial void UpdateVehiculos(Vehiculos instance);
    partial void DeleteVehiculos(Vehiculos instance);
    #endregion
		
		public ConcesionarioRepositoryDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["ConcesionarioConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ConcesionarioRepositoryDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ConcesionarioRepositoryDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ConcesionarioRepositoryDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ConcesionarioRepositoryDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Marcas> Marcas
		{
			get
			{
				return this.GetTable<Marcas>();
			}
		}
		
		public System.Data.Linq.Table<Modelos> Modelos
		{
			get
			{
				return this.GetTable<Modelos>();
			}
		}
		
		public System.Data.Linq.Table<Vehiculos> Vehiculos
		{
			get
			{
				return this.GetTable<Vehiculos>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Marcas")]
	public partial class Marcas : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id_marca;
		
		private string _nombre;
		
		private string _pais;
		
		private System.Nullable<System.DateTime> _anno_creacion;
		
		private EntitySet<Modelos> _Modelos;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onid_marcaChanging(int value);
    partial void Onid_marcaChanged();
    partial void OnnombreChanging(string value);
    partial void OnnombreChanged();
    partial void OnpaisChanging(string value);
    partial void OnpaisChanged();
    partial void Onanno_creacionChanging(System.Nullable<System.DateTime> value);
    partial void Onanno_creacionChanged();
    #endregion
		
		public Marcas()
		{
			this._Modelos = new EntitySet<Modelos>(new Action<Modelos>(this.attach_Modelos), new Action<Modelos>(this.detach_Modelos));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_marca", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id_marca
		{
			get
			{
				return this._id_marca;
			}
			set
			{
				if ((this._id_marca != value))
				{
					this.Onid_marcaChanging(value);
					this.SendPropertyChanging();
					this._id_marca = value;
					this.SendPropertyChanged("id_marca");
					this.Onid_marcaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nombre", DbType="NVarChar(500)")]
		public string nombre
		{
			get
			{
				return this._nombre;
			}
			set
			{
				if ((this._nombre != value))
				{
					this.OnnombreChanging(value);
					this.SendPropertyChanging();
					this._nombre = value;
					this.SendPropertyChanged("nombre");
					this.OnnombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_pais", DbType="NVarChar(500)")]
		public string pais
		{
			get
			{
				return this._pais;
			}
			set
			{
				if ((this._pais != value))
				{
					this.OnpaisChanging(value);
					this.SendPropertyChanging();
					this._pais = value;
					this.SendPropertyChanged("pais");
					this.OnpaisChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_anno_creacion", DbType="Date")]
		public System.Nullable<System.DateTime> anno_creacion
		{
			get
			{
				return this._anno_creacion;
			}
			set
			{
				if ((this._anno_creacion != value))
				{
					this.Onanno_creacionChanging(value);
					this.SendPropertyChanging();
					this._anno_creacion = value;
					this.SendPropertyChanged("anno_creacion");
					this.Onanno_creacionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Marcas_Modelos", Storage="_Modelos", ThisKey="id_marca", OtherKey="id_marca")]
		public EntitySet<Modelos> Modelos
		{
			get
			{
				return this._Modelos;
			}
			set
			{
				this._Modelos.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Modelos(Modelos entity)
		{
			this.SendPropertyChanging();
			entity.Marcas = this;
		}
		
		private void detach_Modelos(Modelos entity)
		{
			this.SendPropertyChanging();
			entity.Marcas = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Modelos")]
	public partial class Modelos : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id_modelo;
		
		private int _id_marca;
		
		private string _modelo;
		
		private string _motor;
		
		private EntitySet<Vehiculos> _Vehiculos;
		
		private EntityRef<Marcas> _Marcas;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onid_modeloChanging(int value);
    partial void Onid_modeloChanged();
    partial void Onid_marcaChanging(int value);
    partial void Onid_marcaChanged();
    partial void OnmodeloChanging(string value);
    partial void OnmodeloChanged();
    partial void OnmotorChanging(string value);
    partial void OnmotorChanged();
    #endregion
		
		public Modelos()
		{
			this._Vehiculos = new EntitySet<Vehiculos>(new Action<Vehiculos>(this.attach_Vehiculos), new Action<Vehiculos>(this.detach_Vehiculos));
			this._Marcas = default(EntityRef<Marcas>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_modelo", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id_modelo
		{
			get
			{
				return this._id_modelo;
			}
			set
			{
				if ((this._id_modelo != value))
				{
					this.Onid_modeloChanging(value);
					this.SendPropertyChanging();
					this._id_modelo = value;
					this.SendPropertyChanged("id_modelo");
					this.Onid_modeloChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_marca", DbType="Int NOT NULL")]
		public int id_marca
		{
			get
			{
				return this._id_marca;
			}
			set
			{
				if ((this._id_marca != value))
				{
					if (this._Marcas.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_marcaChanging(value);
					this.SendPropertyChanging();
					this._id_marca = value;
					this.SendPropertyChanged("id_marca");
					this.Onid_marcaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_modelo", DbType="NVarChar(145)")]
		public string modelo
		{
			get
			{
				return this._modelo;
			}
			set
			{
				if ((this._modelo != value))
				{
					this.OnmodeloChanging(value);
					this.SendPropertyChanging();
					this._modelo = value;
					this.SendPropertyChanged("modelo");
					this.OnmodeloChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_motor", DbType="NVarChar(145)")]
		public string motor
		{
			get
			{
				return this._motor;
			}
			set
			{
				if ((this._motor != value))
				{
					this.OnmotorChanging(value);
					this.SendPropertyChanging();
					this._motor = value;
					this.SendPropertyChanged("motor");
					this.OnmotorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Modelos_Vehiculos", Storage="_Vehiculos", ThisKey="id_modelo", OtherKey="id_modelo")]
		public EntitySet<Vehiculos> Vehiculos
		{
			get
			{
				return this._Vehiculos;
			}
			set
			{
				this._Vehiculos.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Marcas_Modelos", Storage="_Marcas", ThisKey="id_marca", OtherKey="id_marca", IsForeignKey=true)]
		public Marcas Marcas
		{
			get
			{
				return this._Marcas.Entity;
			}
			set
			{
				Marcas previousValue = this._Marcas.Entity;
				if (((previousValue != value) 
							|| (this._Marcas.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Marcas.Entity = null;
						previousValue.Modelos.Remove(this);
					}
					this._Marcas.Entity = value;
					if ((value != null))
					{
						value.Modelos.Add(this);
						this._id_marca = value.id_marca;
					}
					else
					{
						this._id_marca = default(int);
					}
					this.SendPropertyChanged("Marcas");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Vehiculos(Vehiculos entity)
		{
			this.SendPropertyChanging();
			entity.Modelos = this;
		}
		
		private void detach_Vehiculos(Vehiculos entity)
		{
			this.SendPropertyChanging();
			entity.Modelos = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Vehiculos")]
	public partial class Vehiculos : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id_vehiculo;
		
		private string _nombre;
		
		private string _tipo;
		
		private System.Nullable<int> _id_modelo;
		
		private EntityRef<Modelos> _Modelos;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onid_vehiculoChanging(int value);
    partial void Onid_vehiculoChanged();
    partial void OnnombreChanging(string value);
    partial void OnnombreChanged();
    partial void OntipoChanging(string value);
    partial void OntipoChanged();
    partial void Onid_modeloChanging(System.Nullable<int> value);
    partial void Onid_modeloChanged();
    #endregion
		
		public Vehiculos()
		{
			this._Modelos = default(EntityRef<Modelos>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_vehiculo", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id_vehiculo
		{
			get
			{
				return this._id_vehiculo;
			}
			set
			{
				if ((this._id_vehiculo != value))
				{
					this.Onid_vehiculoChanging(value);
					this.SendPropertyChanging();
					this._id_vehiculo = value;
					this.SendPropertyChanged("id_vehiculo");
					this.Onid_vehiculoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nombre", DbType="VarChar(145)")]
		public string nombre
		{
			get
			{
				return this._nombre;
			}
			set
			{
				if ((this._nombre != value))
				{
					this.OnnombreChanging(value);
					this.SendPropertyChanging();
					this._nombre = value;
					this.SendPropertyChanged("nombre");
					this.OnnombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tipo", DbType="VarChar(145)")]
		public string tipo
		{
			get
			{
				return this._tipo;
			}
			set
			{
				if ((this._tipo != value))
				{
					this.OntipoChanging(value);
					this.SendPropertyChanging();
					this._tipo = value;
					this.SendPropertyChanged("tipo");
					this.OntipoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_modelo", DbType="Int")]
		public System.Nullable<int> id_modelo
		{
			get
			{
				return this._id_modelo;
			}
			set
			{
				if ((this._id_modelo != value))
				{
					if (this._Modelos.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_modeloChanging(value);
					this.SendPropertyChanging();
					this._id_modelo = value;
					this.SendPropertyChanged("id_modelo");
					this.Onid_modeloChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Modelos_Vehiculos", Storage="_Modelos", ThisKey="id_modelo", OtherKey="id_modelo", IsForeignKey=true)]
		public Modelos Modelos
		{
			get
			{
				return this._Modelos.Entity;
			}
			set
			{
				Modelos previousValue = this._Modelos.Entity;
				if (((previousValue != value) 
							|| (this._Modelos.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Modelos.Entity = null;
						previousValue.Vehiculos.Remove(this);
					}
					this._Modelos.Entity = value;
					if ((value != null))
					{
						value.Vehiculos.Add(this);
						this._id_modelo = value.id_modelo;
					}
					else
					{
						this._id_modelo = default(Nullable<int>);
					}
					this.SendPropertyChanged("Modelos");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
