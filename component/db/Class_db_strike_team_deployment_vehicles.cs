// Derived from KiAspdotnetFramework/component/db/Class~db~template~kicrudhelped~items.cs~template

using Class_db;
using Class_db_trail;
using kix;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

namespace Class_db_strike_team_deployment_vehicles
  {
  public class TClass_db_strike_team_deployment_vehicles: TClass_db
    {

    private class strike_team_deployment_vehicle_summary
      {
      public string id;
      }

    private readonly TClass_db_trail db_trail = null;

    public TClass_db_strike_team_deployment_vehicles() : base()
      {
      db_trail = new TClass_db_trail();
      }

    internal bool BeNone
      (
      string deployment_id,
      string service_strike_team_management_footprint
      )
      {
      Open();
      using var my_sql_command = new MySqlCommand
        (
        "select count(*)"
        + " from strike_team_deployment_vehicle"
        +   (service_strike_team_management_footprint.Length > 0 ? " join vehicle on (vehicle.id=strike_team_deployment_vehicle.vehicle_id)" : k.EMPTY)
        + " where deployment_id = '" + deployment_id + "'"
        +   (service_strike_team_management_footprint.Length > 0 ? " and service_id in (" + service_strike_team_management_footprint + ")" : k.EMPTY),
        connection
        );
      var be_none = ("0" == my_sql_command.ExecuteScalar().ToString());
      Close();
      return be_none;
      }

    internal bool BeTagTransponderAvailableForAssignment
      (
      string deployment_id,
      string vehicle_id,
      string tactical_name,
      string transponder_name
      )
      {
      Open();
      using var my_sql_command = new MySqlCommand
        (
        "select 1"
        + " from strike_team_deployment_vehicle"
        + " where deployment_id = '" + deployment_id + "'"
        +   " and vehicle_id <> '" + vehicle_id + "'"
        +   " and (tactical_name = '" + tactical_name + "' or transponder_name = '" + transponder_name + "')",
        connection
        );
      var be_tag_transponder_available_for_assignment = (null == my_sql_command.ExecuteScalar());
      Close();
      return be_tag_transponder_available_for_assignment;
      }

    public bool Bind(string partial_spec, object target)
      {
      var concat_clause = "concat(IFNULL(deployment_id,'-'),'|',IFNULL(vehicle_id,'-'))";
      Open();
      ((target) as ListControl).Items.Clear();
      using var my_sql_command = new MySqlCommand
        (
        "select id"
        + " , CONVERT(" + concat_clause + " USING utf8) as spec"
        + " from strike_team_deployment_vehicle"
        + " where " + concat_clause + " like '%" + partial_spec.ToUpper() + "%'"
        + " order by spec",
        connection
        );
      var dr = my_sql_command.ExecuteReader();
      while (dr.Read())
        {
        ((target) as ListControl).Items.Add(new ListItem(dr["spec"].ToString(), dr["id"].ToString()));
        }
      dr.Close();
      Close();
      return ((target) as ListControl).Items.Count > 0;
      }

    internal void BindBaseDataList
      (
      string sort_order,
      bool be_sort_order_ascending,
      object target,
      string deployment_id,
      bool do_include_all_eligible_vehicles,
      string service_strike_team_management_footprint
      )
      {
      Open();
      using var my_sql_command = new MySqlCommand
        (
        "select strike_team_deployment_vehicle.id as id"
        + " , vehicle.id as vehicle_id"
        + " , service.id as service_id"
        + " , service.short_name as service"
        + " , vehicle.name as name"
        + " , patient_care_level.description as patient_care_level"
        + " , vehicle_kind.description as kind"
        + " , pa_doh_decal_num"
        + " , tow_capacity.short_description as tow_capacity"
        + " , fuel.description as fuel"
        + " , IF(be_four_or_all_wheel_drive,'YES','no') as be_four_or_all_wheel_drive"
        + " , tactical_name as saved_tactical_name"
        + " , tactical_name"
        + " , transponder_name as saved_transponder_name"
        + " , transponder_name"
        + " , IFNULL(vehicle.elaboration,'') as elaboration"
        + " from vehicle"
        +   " join service on (service.id=vehicle.service_id)"
        +   " join county_region_map on (county_region_map.county_code=service.county_code)"
        +   " join strike_team_deployment on (strike_team_deployment.id = '" + deployment_id + "')"
        +   " join patient_care_level on (patient_care_level.id=vehicle.patient_care_level_id)"
        +   " join vehicle_kind on (vehicle_kind.id=vehicle.kind_id)"
        +   " join tow_capacity on (tow_capacity.id=vehicle.tow_capacity_id)"
        +   " join fuel on (fuel.id=vehicle.fuel_id)"
        +   (do_include_all_eligible_vehicles ? " left" : k.EMPTY) + " join strike_team_deployment_vehicle on (strike_team_deployment_vehicle.vehicle_id=vehicle.id and strike_team_deployment_vehicle.deployment_id = '" + deployment_id + "')"
        + " where" + (do_include_all_eligible_vehicles ? " (vehicle.be_active or strike_team_deployment_vehicle.id is not null)" : " TRUE")
        +   (service_strike_team_management_footprint.Length > 0 ? " and service.id in (" + service_strike_team_management_footprint + ")" : k.EMPTY) 
        + " order by " + sort_order.Replace("%",(be_sort_order_ascending ? " asc" : " desc"))
        ,
        connection
        );
      ((target) as BaseDataList).DataSource = my_sql_command.ExecuteReader();
      ((target) as BaseDataList).DataBind();
      Close();
      }

    public void BindDirectToListControl
      (
      object target,
      string deployment_id
      )
      {
      Open();
      (target as ListControl).Items.Clear();
      using var my_sql_command = new MySqlCommand
        (
        "SELECT vehicle.id as id"
        + " , @static_designator := concat(service.short_name,' ',vehicle.name)"
        + " , @dynamic_designator := IF(tactical_name = @static_designator or tactical_name is null,concat(@static_designator,' (',vehicle_kind.description,')'),concat(tactical_name,' [',@static_designator,' (',vehicle_kind.description,')]'))"
        + " , IFNULL(@dynamic_designator,'(none)') as spec"
        + " FROM strike_team_deployment_vehicle"
        +   " join vehicle on (vehicle.id=strike_team_deployment_vehicle.vehicle_id)"
        +   " join service on (service.id=vehicle.service_id)"
        +   " join vehicle_kind on (vehicle_kind.id=vehicle.kind_id)"
        + " where deployment_id = '" + deployment_id + "'"
        + " order by spec",
        connection
        );
      var dr = my_sql_command.ExecuteReader();
      while (dr.Read())
        {
        ((target) as ListControl).Items.Add(new ListItem(dr["spec"].ToString(), dr["id"].ToString()));
        }
      dr.Close();
      Close();
      }

    public bool Delete(string id)
      {
      var result = true;
      Open();
      try
        {
        using var my_sql_command = new MySqlCommand(db_trail.Saved("delete from strike_team_deployment_vehicle where id = \"" + id + "\""), connection);
        my_sql_command.ExecuteNonQuery();
        }
      catch(System.Exception e)
        {
        if (e.Message.StartsWith("Cannot delete or update a parent row: a foreign key constraint fails", true, null))
          {
          result = false;
          }
        else
          {
          throw;
          }
        }
      Close();
      return result;
      }

    internal string DesignatorOnDeploymentWithCompetingTacticalName
      (
      string deployment_id,
      string id,
      string tactical_name
      )
      {
      Open();
      using var my_sql_command = new MySqlCommand
        (
        "select IFNULL(concat(service.name,' ',vehicle.name),'')"
        + " from strike_team_deployment_vehicle"
        +   " join vehicle on (vehicle.id=strike_team_deployment_vehicle.vehicle_id)"
        +   " join service on (service.id=vehicle.service_id)"
        + " where deployment_id = '" + deployment_id + "'"
        +   " and tactical_name = '" + tactical_name + "'"
        +   " and strike_team_deployment_vehicle.id <> '" + id + "'",
        connection
        );
      var designator_with_competing_tactical_name_obj = my_sql_command.ExecuteScalar();
      Close();
      if (designator_with_competing_tactical_name_obj == null)
        {
        return k.EMPTY;
        }
      else
        {
        return designator_with_competing_tactical_name_obj.ToString();
        }
      }

    internal string DesignatorOnDeploymentWithCompetingTransponderName
      (
      string deployment_id,
      string id,
      string transponder_name
      )
      {
      Open();
      using var my_sql_command = new MySqlCommand
        (
        "select IFNULL(concat(service.name,' ',vehicle.name),'')"
        + " from strike_team_deployment_vehicle"
        +   " join vehicle on (vehicle.id=strike_team_deployment_vehicle.vehicle_id)"
        +   " join service on (service.id=vehicle.service_id)"
        + " where deployment_id = '" + deployment_id + "'"
        +   " and transponder_name = '" + transponder_name + "'"
        +   " and strike_team_deployment_vehicle.id <> '" + id + "'",
        connection
        );
      var designator_with_competing_transponder_name_obj = my_sql_command.ExecuteScalar();
      Close();
      if (designator_with_competing_transponder_name_obj == null)
        {
        return k.EMPTY;
        }
      else
        {
        return designator_with_competing_transponder_name_obj.ToString();
        }
      }

    public bool Get
      (
      string id,
      out string deployment_id,
      out string vehicle_id,
      out string tactical_name,
      out string transponder_name
      )
      {
      deployment_id = k.EMPTY;
      vehicle_id = k.EMPTY;
      tactical_name = k.EMPTY;
      transponder_name = k.EMPTY;
      var result = false;
      //
      Open();
      using var my_sql_command = new MySqlCommand("select * from strike_team_deployment_vehicle where CAST(id AS CHAR) = \"" + id + "\"", connection);
      var dr = my_sql_command.ExecuteReader();
      if (dr.Read())
        {
        deployment_id = dr["deployment_id"].ToString();
        vehicle_id = dr["vehicle_id"].ToString();
        tactical_name = dr["tactical_name"].ToString();
        transponder_name = dr["trnsponder_name"].ToString();
        result = true;
        }
      dr.Close();
      Close();
      return result;
      }

    public void Set
      (
      string id,
      string deployment_id,
      string vehicle_id,
      string tactical_name,
      string transponder_name
      )
      {
      var childless_field_assignments_clause = k.EMPTY
      + "deployment_id = NULLIF('" + deployment_id + "','')"
      + " , vehicle_id = NULLIF('" + vehicle_id + "','')"
      + " , tactical_name = NULLIF(LEFT('" + tactical_name + "',63),'')"
      + " , transponder_name = NULLIF('" + transponder_name + "','')"
      + k.EMPTY;
      db_trail.MimicTraditionalInsertOnDuplicateKeyUpdate
        (
        target_table_name:"strike_team_deployment_vehicle",
        key_field_name:"id",
        key_field_value:id,
        childless_field_assignments_clause:childless_field_assignments_clause,
        additional_match_condition:" or (deployment_id = '" + deployment_id + "' and vehicle_id = '" + vehicle_id + "')"
        );
      }

    internal object Summary(string id)
      {
      Open();
      using var my_sql_command = new MySqlCommand
        (
        "SELECT *"
        + " FROM strike_team_deployment_vehicle"
        + " where id = '" + id + "'",
        connection
        );
      var dr = my_sql_command.ExecuteReader();
      dr.Read();
      var the_summary = new strike_team_deployment_vehicle_summary()
        {
        id = id
        };
      Close();
      return the_summary;
      }

    } // end TClass_db_strike_team_deployment_vehicles

  }
