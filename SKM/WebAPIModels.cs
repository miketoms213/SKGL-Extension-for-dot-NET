﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SKM.V3.Models
{

    /// <summary>
    ///   <para>
    ///     All the classes that are either used as a paramter for an API method or represent the
    ///     data that is being sent back.
    ///   </para>
    /// </summary>
    internal class NamespaceDoc
    {

    }

    public class GetCustomerLicensesModel
    {
        public int CustomerId { get; set; }

        public bool Detailed { get; set; }
    }

    public class GetCustomerLicensesResult : BasicResult
    {
        public List<LicenseKey> LicenseKeys { get; set; }
    }

    public class RemoveCustomerModel
    {
        public int CustomerId { get; set; }
    }
    public class AddCustomerModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
    }

    public class AddCustomerResult : BasicResult
    {
        public int CustomerId { get; set; }
    }
    public class DeactivateModel : KeyLockModel
    {
        [DefaultValue("")]
        public string MachineCode { get; set; }
    }

    public class KeyInfoModel
    {
        public int ProductId { get; set; }
        /// <summary>
        /// The Key Id, eg. 12345.
        /// </summary>
        public string Key { get; set; }

        public bool Sign { get; set; }
        public int FieldsToReturn { get; set; }
    }

    public class CreateKeyModel
    {
        public int ProductId { get; set; }
        public int Period { get; set; }
        public bool F1 { get; set; }
        public bool F2 { get; set; }
        public bool F3 { get; set; }
        public bool F4 { get; set; }
        public bool F5 { get; set; }
        public bool F6 { get; set; }
        public bool F7 { get; set; }
        public bool F8 { get; set; }
        [DefaultValue("")]
        public string Notes { get; set; }
        public bool Block { get; set; }
        public int CustomerId { get; set; } // maybe int instead?
        public bool TrialActivation { get; set; }
        public bool AutomaticActivation { get; set; }
        public int MaxNoOfMachines { get; set; }
        public string AllowedMachines { get; set; }
    }
    public class CreateKeyResult : BasicResult
    {
        public string Key { get; set; }
    }
    public class GetKeysModel
    {
        /// <summary>
        /// The product id
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// If there are more than 100 keys, only 99 will be returned
        /// on the first page. in order to obtain the remaining licenses, 
        /// increment this parameter by 1.
        /// </summary>
        [DefaultValue(1)]
        public int Page { get; set; }
        /// <summary>
        /// Specifies the way to order the result. The order by field has the
        /// following structure: fieldName [ascending|descending]. For example, 
        /// If you want to order by the feature field 1 (F1), you should use F1.
        /// If you want it in descending order, please add the descending keywords 
        /// right after the field, eg. F1 descending. The ascending keyword is 
        /// the default, hence optional.
        /// </summary>
        public string OrderBy { get; set; }
        /// <summary>
        /// Sorts the result so that only the license keys that satisfy the
        /// criterion will be displayed. Please see:
        /// https://support.serialkeymanager.com/kb/searching-for-licenses-using-linq-queries
        /// </summary>
        public string SearchQuery { get; set; }
    }

    public class GetKeysResult : BasicResult
    {
        /// <summary>
        /// A list of <see cref="LicenseKey"/> objects.
        /// </summary>
        public List<LicenseKey> LicenseKeys { get; set; }
        /// <summary>
        /// The number of licenses returned in the request, eg. size
        /// of the returned list.
        /// </summary>
        public int Returned { get; set; }
        /// <summary>
        /// The total number of keys available that satisfy the condition.
        /// For example, if search query is empty, the total is the number
        /// of license keys in the entire product. Otherwise, it's the 
        /// number of results of that query. By default, only 99 license 
        /// keys will be returned in a single request. There may still 
        /// be more license keys, which are obtained by increasing the 
        /// Page parameter.
        /// </summary>
        public int Total { get; set; }
    }

    public class ActivateModel 
    {
        public int ProductId { get; set; }
        /// <summary>
        /// The Key Id, eg. 12345.
        /// </summary>
        public string Key { get; set; }
        public bool Sign { get; set; }

        public string MachineCode { get; set; }

        public int FieldsToReturn { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class KeyInfoResult : BasicResult
    {
        public LicenseKey LicenseKey { get; set; }
    }

    public class MachineLockLimit : KeyLockModel
    {
        public int NumberOfMachines { get; set; }
    }


    public class ChangeNotesModel : KeyLockModel
    {
        public string Notes { get; set; }
    }



    /// <summary>
    /// Input parameters to KeyLock method.
    /// </summary>
    public class KeyLockModel
    {
        /// <summary>
        /// The id of the product you want to access. You can find it
        /// when you are logged in on https://serialkeymanager.com/docs/api/v3/KeyLock
        /// and select the product in the drop down list.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// The Key String, i.e. ABCDE-ABCDE-ABCDE-ABCDE.
        /// </summary>
        public string Key { get; set; }
    }
    /// <summary>
    /// The result of <see cref="SKM.V3.Methods.Auth.KeyLock(string, KeyLockModel)/>
    /// </summary>
    public class KeyLockResult : BasicResult
    {
        public long KeyId { get; set; }
        public string Token { get; set; }

    }

    public class AddDataObjectToKeyModel : KeyLockModel
    {
        public string Name { get; set; }
        public string StringValue { get; set; }
        public int IntValue { get; set; }
    }


    public class ListDataObjectsToKeyModel : KeyLockModel
    {
        /// <summary>
        /// Lists the names that contain the desired string only.
        /// </summary>
        [DefaultValue("")]
        public string Contains { get; set; }
    }


    /// <summary>
    /// Used to identify a data object.
    /// </summary>
    public class ChangeStringValueToKeyModel : KeyLockModel, IChangeValueModel
    {
        public long Id { get; set; }
        public string StringValue { get; set; }
    }

    /// <summary>
    /// Used to identify a data object.
    /// </summary>
    public class ChangeIntValueToKeyModel : KeyLockModel, IChangeValueModel
    {
        public long Id { get; set; }

        public int IntValue { get; set; }

        public int Bound { get; set; }

        public bool EnableBound { get; set; }
    }


    /// <summary>
    /// Used to remove a data object.
    /// </summary>
    public class RemoveDataObjectToKeyModel : KeyLockModel, IChangeValueModel
    {
        public long Id { get; set; }
    }



    internal interface IAddOrListDataObjectsModel
    {
        /// <summary>
        /// Indicates if the data object should be added to a
        /// license key, a product or the entire user account. 
        /// <see cref="DataObject"/>
        /// </summary>
        DataObjectType ReferencerType { get; set; }

        /// <summary>
        /// The id of the Referencer. It can either be an id to a product that
        /// you have or to a license key. When ReferencerType is set to User,
        /// there is no need to set this value.
        /// </summary>
        int ReferencerId { get; set; }
    }

    /// <summary>
    /// Used to add a new Data Object.
    /// </summary>
    public class AddDataObjectModel : IAddOrListDataObjectsModel
    {
        /// <summary>
        /// The name of the data object. Max 10 characters.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// A string value (text) to store. Max 100 characters.
        /// </summary>
        public string StringValue { get; set; }
        /// <summary>
        /// An int value (int32) to store.
        /// </summary>
        public int IntValue { get; set; }

        /// <summary>
        /// Indicates if the data object should be added to a
        /// license key, a product or the entire user account. 
        /// <see cref="DataObject"/>
        /// </summary>
        public DataObjectType ReferencerType { get; set; }

        /// <summary>
        /// The id of the Referencer. It can either be an id to a product
        /// that you have or to a license key. When ReferencerType is set
        /// to User, there is no need to set this value.
        /// </summary>
        public int ReferencerId { get; set; }

    }

    /// <summary>
    /// Used to list Data Objects.
    /// </summary>
    public class ListDataObjectsModel : IAddOrListDataObjectsModel
    {

        /// <summary>
        /// Indicates if the data object is associated with a license key, 
        /// a product or the entire user account. User = 0, Product = 1, Key = 2.
        /// </summary>
        public DataObjectType ReferencerType { get; set; }

        /// <summary>
        /// The id of the Referencer. It can either be an id to a product that
        /// you have or to a license key. When ReferencerType is set to User,
        /// there is no need to set this value.
        /// </summary>
        public int ReferencerId { get; set; }

        /// <summary>
        /// Shows only Data Objects where the name contains the following string.
        /// </summary>
        public string Contains { get; set; }

        /// <summary>
        /// If set to true, all data objects will be returned, that is, 
        /// both those associated with your entire account, a specific
        /// product and a license key. In addition, each data object
        /// item will include the ReferencerType and its Id. Otherwise,
        /// i.e. when set to false, only the data objects associated 
        /// with the user, product or key will be returned, without the 
        /// ReferencerType and its Id.
        /// </summary>
        public bool ShowAll { get; set; }
    }



    /// <summary>
    /// Used to identify a data object.
    /// </summary>
    internal interface IChangeValueModel
    {
        /// <summary>
        /// The unique object id for the data object.
        /// </summary>
        long Id { get; set; }
    }

    /// <summary>
    /// Used to identify a data object.
    /// </summary>
    public class ChangeStringValueModel : IChangeValueModel
    {
        /// <summary>
        /// The unique object id for the data object.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// A string value (text) to store. Max 100 characters.
        /// </summary>
        public string StringValue { get; set; }
    }

    /// <summary>
    /// Used to identify a data object.
    /// </summary>
    public class ChangeIntValueModel : IChangeValueModel
    {
        /// <summary>
        /// The unique object id for the data object.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// This is either the new int value that should be assigned to the Data Object
        /// when using <see cref="Data.SetIntValue(AuthDetails, ChangeIntValueModel)"/>
        /// in which case it can be a signed int32, eg. 10, and -10 OR it is a the value that
        /// should be added to the current IntValue of an existing Data Object, in which case
        /// this value will be treated as an unsigned value, eg. 10 = -10. The latter case is
        /// relevant for <see cref="Data.IncrementIntValue(AuthDetails, ChangeIntValueModel)"/>
        /// and <see cref="Data.DecrementIntValue(AuthDetails, ChangeIntValueModel)"/>.
        /// </summary>
        public int IntValue { get; set; }


        /// <summary>
        /// If set to true, it will be possible to specify an upper/lower bound. 
        /// (for Increment Int Value) For example, if you set the Bound parameter (below) to 10, you
        /// will be able to increment the int value until you reach ten (inclusive).
        /// Once the upper bound is reached, an error will be thrown.
        /// (for Decrement Int Value) For example, if you set the Bound parameter (below) to 0, 
        /// you will be able to decrement the int value until you reach zero (inclusive).
        /// Once the lower bound is reached, an error will be thrown.
        /// </summary>
        public bool EnableBound { get; set; }

        /// <summary>
        /// This is the upper/lower bound that will be enforced on the increment or
        /// decrement operation. It will only be enforced if EnableBound
        /// is set to true. Please read the description above.
        /// </summary>
        public int Bound { get; set; }
    }

    /// <summary>
    /// Used to remove a data object.
    /// </summary>
    public class RemoveDataObjectModel : IChangeValueModel
    {
        /// <summary>
        /// The unique object id for the data object.
        /// </summary>
        public long Id { get; set; }
    }



    /// <summary>
    /// Stores the parameters that are required by the Extend License method.
    /// </summary>
    public class ExtendLicenseModel
    {
        /// <summary>
        /// The id of the product you want to access. You can find it
        /// when you are logged in on https://serialkeymanager.com/docs/api/v3/ExtendLicense
        /// and select the product in the drop down list.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// The Key String, i.e. ABCDE-ABCDE-ABCDE-ABCDE.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The number of days the license should be extended.
        /// </summary>
        public int NoOfDays { get; set; }
    }

    /// <summary>
    /// Stores the parameters required by AddFeature and RemoveFeature methods.
    /// </summary>
    public class FeatureModel
    {
        public int ProductId { get; set; }
        /// <summary>
        /// The Key String, i.e. ABCDE-ABCDE-ABCDE-ABCDE.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// From 1 to 8.
        /// </summary>
        public int Feature { get; set; }
    }



    /// <summary>
    /// Used to return the list of <see cref="DataObject"/>
    /// </summary>
    public class ListOfDataObjectsResult : BasicResult
    {
        /// <summary>
        /// A list of data objects, where each data object is of the type
        /// <see cref="DataObject"/>. Note, when <see cref="ListDataObjectsModel.ShowAll"/>
        /// is set to true, the data objects will contain additional information about the
        /// referencer. So, when <see cref="ListDataObjectsModel.ShowAll"/>, you can convert
        /// the <see cref="DataObject"/> to a <see cref="DataObjectWithReferencer"/> using
        /// implicit or explicit conversion.
        /// </summary>
        public List<DataObject> DataObjects { get; set; }
    }


    /// <summary>
    /// Used to return the list of <see cref="DataObjectWithReferencer"/> 
    /// for internal purposes.
    /// </summary>
    internal class ListOfDataObjectsResultWithReferencer : BasicResult
    {
        public List<DataObjectWithReferencer> DataObjects { get; set; }
    }


    /// <summary>
    /// Used to return the object Id of a Data Object.
    /// </summary>
    public class DataObjectIdResult : BasicResult
    {
        /// <summary>
        /// The unique object id for the new data object.
        /// </summary>
        public long Id { get; set; }
    }

    /// <summary>
    /// A simple result that tells if a request is successful,
    /// and optionally provides a message.
    /// </summary>
    public class BasicResult
    {
        /// <summary>
        /// Tells whether the result is successful or unsuccessful.
        /// </summary>
        public ResultType Result { get; set; }

        /// <summary>
        /// The message that provides additional information about the result.
        /// If it's a successful result, null will be returned. Otherwise,
        /// in case of an error, a short message will be returned describing the error.
        /// </summary>
        public string Message { get; set; }
    }

    /// <summary>
    /// Indicates whether a result was successful or unsuccessful.
    /// </summary>
    public enum ResultType
    {
        Success,
        Error
    }

    /// <summary>
    /// Stores information that is required to identify yourself to SKM.
    /// This includes the Token and Version.
    /// </summary>
    [Serializable]
    public class AuthDetails
    {
        /// <summary>
        /// This token helps SKM to identify you and ensure that
        /// you have the required permission. Read more here 
        /// https://serialkeymanager.com/docs/api/v3/Auth.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// The version of the method you want to access. By default,
        /// it's not needed, however, if you would like to access
        /// a newer version, it can be specified. You can read more here
        /// https://serialkeymanager.com/docs/api/v3/Versioning
        /// </summary>
        public int Version { get; set; }
    }
}
