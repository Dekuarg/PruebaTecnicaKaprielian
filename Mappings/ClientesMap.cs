using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using PruebaTecnicaKaprielian.Models;

namespace PruebaTecnicaKaprielian.Mappings
{
    public class ClientesMap : IAutoMappingOverride<Clientes>
    {
        public void Override(AutoMapping<Clientes> mapping)
        {
            mapping.Table("clientes");
            mapping.Id(x => x.Id).GeneratedBy.Identity().Unique().Not.Nullable();
            mapping.Map(x => x.Nombres).Length(15).Column("nombres").Not.Nullable();
            mapping.Map(x => x.Apellidos).Length(10).Column("apellidos").Not.Nullable();
            mapping.Map(x => x.FechaNacimiento).Column("fecha_de_nacimiento").Nullable();
            mapping.Map(x => x.Cuit).Length(45).Column("cuit").Not.Nullable();
            mapping.Map(x => x.TelefonoCelular).Length(20).Column("telefono").Not.Nullable();
            mapping.Map(x => x.Email).Length(25).Column("email").Not.Nullable();
            mapping.Map(x => x.Domicilio).Length(45).Column("domicilio").Nullable();

        }
    }
}
