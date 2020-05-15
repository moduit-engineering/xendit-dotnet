
  
# Xendit .NET Library    
[![NuGet](https://img.shields.io/nuget/v/xendit.dotnet.svg)](https://www.nuget.org/packages/Xendit.Dotnet/) [![MIT licensed](https://img.shields.io/badge/license-MIT-blue.svg)](./LICENSE.md) ![Release Build](https://github.com/moduit-engineering/xendit-dotnet/workflows/Release%20Build/badge.svg?branch=master) 
  
This library is the abstraction of Xendit API for access from applications written with C# .NET.    
    
Please note that this library is not official from Xendit. You can refer to [Xendit Github](https://github.com/xendit/) for the complete list of their official API client libraries.    
    
# Table of Contents    
    
 1. [API Documentation](#api-documentation)    
 2. [Requirements](#requirements)    
 3. [Usage](#usage)    
 4. [Disbursement Services](#disbursement-services)    
    - [Create a disbursement](#create-a-disbursement)    
    - [Get banks with available disbursement service](#get-banks-with-available-disbursement-service)    
    - [Get a disbursement by external ID](#get-a-disbursement-by-external-id)    
    - [Get a disbursement by ID](#get-a-disbursement-by-id)    
 5. [Invoice services](#invoice-services)    
    - [Create an invoice](#create-an-invoice)    
    - [Get an invoice by ID](#get-an-invoice-by-id)    
    - [Get all invoices](#get-all-invoices)    
    - [Expire an invoice](#expire-an-invoice)    
 6. [Virtual Account Services](#virtual-account-services)    
    - [Create a fixed virtual account](#create-a-fixed-virtual-account)    
      - [Closed virtual account](#closed-virtual-account)    
      - [Opened virtual account](#opened-virtual-account)    
    - [Get banks with available virtual account service](#get-banks-with-available-virtual-account-service)    
    - [Get a fixed virtual account by ID](#get-a-fixed-virtual-account-by-id)    
    - [Expire a fixed virtual account](#expire-a-fixed-virtual-account)    
 7. [Batch Disbursement Services](#batch-disbursement-services)    
    - [Batch disbursement item](#batch-disbursement-item)    
    - [Create a batch disbursement](#create-a-batch-disbursement)    
    - [Get banks with available disbursement service](#get-banks-with-available-disbursement-service-1)  
 8. [E-Wallet Services](#e-wallet-services)
    - [Create a LinkAja payment](#create-a-linkaja-payment)
    - [Create a Dana payment](#create-a-dana-payment)
    - [Create an OVO payment](#create-an-ovo-payment)
    - [Get an e-wallet payment](#get-an-e-wallet-payment)   
 9. [Exception Handling](#exception-handling)    
 10. [Contributing](#contributing)    
 11. [TODO](#todo)    
    
## API Documentation    
Please check [Xendit API Reference](https://xendit.github.io/apireference/).    
    
## Requirements    
This library is built on .NET Standard 2.0. You only need to make sure that your code is compatible with .NET Standard 2.0, if not, you can build this project on other .NET version easily.    
    
## Usage     
You need to use secret API key in order to use functionality in this library. The key can be obtained from your [Xendit Dashboard](https://dashboard.xendit.co/settings/developers#api-keys).    
    
```csharp    
using Xendit.ApiClient;    
    
public class Program
{    
    public static void Main()    
    {    
        var xendit = new XenditClient("PUT YOUR API KEY HERE");    
    
        // The rest of the code...    
    }    
}    
```    
For complete configuration, you can use the `XenditClient` constructor that accepts `XenditConfiguration`.    
    
Example: Create a specified Fixed Virtual Account (assuming your code is asynchronous, otherwise you can easily call `.Result` or `.GetAwaiter().GetResult()` after the async method depending on your case).    
    
```csharp    
using System.Threading.Tasks;    
using Xendit.ApiClient.Constants;    
using Xendit.ApiClient.VirtualAccount;    
    
public class Program
{    
    public static Main()    
    {    
        MainBusiness().Wait();    
    }    
    
    private async Task MainBusiness()    
    {    
        var xendit = new XenditClient("PUT YOUR API KEY HERE");    
    
        // You can create non-specified fixed VA number by not providing `VirtualAccountNumber` property value.    
        var requestedVA = new XenditVACreateRequest    
        {    
            ExternalId = "VA_fixed-1234567890",    
            Name = "Steve Woznike",    
            BankCode = XenditVABankCode.MANDIRI,    
            VirtualAccountNumber = "9999000002"    
        };
    
        var va = await xendit.VirtualAccount.CreateAsync(requestedVA);    
    }    
}    
```    
    
Note: in a real project, we recommend to use dependency injection to create `XenditClient` object as singleton, you can also use `IXenditClient` interface for your unit tests.    
    
### Disbursement Services    
    
#### Create a disbursement    
    
```csharp    
var requestedDisbursement = new XenditDisbursementCreateRequest    
{    
    ExternalId = "My-Disb-1234567890",    
    Amount = 125000,    
    BankCode = XenditDisbursementBankCode.MANDIRI,    
    AccountHolderName = "Andilau Sinarasa",    
    AccountNumber = "1234567890",    
    Description = "Disbursement description." };    
    
var disbursement = await xendit.Disbursement.CreateAsync(requestedDisbursement);    
```    
    
#### Get banks with available disbursement service    
    
```csharp    
var availableDisbBanks = await xendit.Disbursement.GetAvailableBanksAsync();    
```    
    
#### Get a disbursement by external ID    
    
```csharp    
var disbursement = await xendit.Disbursement.GetByExternalIdAsync("EXAMPLE_EXTERNAL_ID");    
```    
    
#### Get a disbursement by ID    
    
```csharp    
var disbursement = await xendit.Disbursement.GetByIdAsync("EXAMPLE_ID");    
```    
    
[Back to top](#table-of-contents)    
    
### Invoice services    
    
#### Create an invoice    
    
```csharp    
var requestedInvoice = new XenditInvoiceCreateRequest    
{    
    ExternalId = "My-Invoice-1234567890",    
    Amount = 75000,    
    PayerEmail = "customer@example.com",    
    Description = "Invoice for a random gadget" };    
    
var invoice = await xendit.Invoice.CreateAsync(requestedInvoice);    
```    
    
You can bind the invoice to a Virtual Account by providing Virtual Account Id to property `VANumberId` of `XenditInvoiceCreateRequest` above.    
    
#### Get an invoice by ID    
    
```csharp    
var invoice = await xendit.Invoice.GetAsync("EXAMPLE_ID");    
```    
    
#### Get all invoices    
    
```csharp    
var options = new XenditInvoiceOptions    
{    
    Limit = 3,    
    Statuses = new List<XenditInvoiceStatus> { XenditInvoiceStatus.SETTLED, XenditInvoiceStatus.EXPIRED }    
};    
    
var invoices = await xendit.Invoice.GetAllAsync(options);    
```    
    
#### Expire an invoice    
    
```csharp    
var invoice = await xendit.Invoice.ExpireAsync("EXAMPLE_ID");    
```    
    
[Back to top](#table-of-contents)    
    
### Virtual Account Services    
    
#### Create a fixed virtual account    
    
##### Closed virtual account    
    
<table>    
<tr>    
<td>    
<pre>    
new XenditVACreateRequest    
{    
    ExternalId = "my-VA-fixed-closed-1234568",    
    BankCode = XenditVABankCode.BNI,    
    Name = "VA Test",    
    IsClosedVA = true,    
    ExpectedAmount = 1350000    
};    
</pre>    
</td>    
</tr>    
</table>    
    
##### Opened virtual account    
    
<table>    
<tr>    
<td>    
<pre>    
new XenditVACreateRequest    
{    
    ExternalId = "my-VA-fixed-closed-1234568",    
    BankCode = XenditVABankCode.BNI,    
    Name = "VA Test",    
};    
</pre>    
</td>    
</tr>    
</table>    
    
    
```csharp    
// Just unassign `IsClosedVA` and `ExpectedAmount` to create Opened VA.    
 var requestedVA = new XenditVACreateRequest    
{    
    ExternalId = "my-VA-fixed-closed-1234568",    
    BankCode = XenditVABankCode.BNI,    
    Name = "VA Test",    
    IsClosedVA = true,    
    ExpectedAmount = 1350000 };    
    
var va = await xendit.VirtualAccount.CreateAsync(requestedVA);    
```    
    
#### Get banks with available virtual account service    
    
```csharp    
var availableVABanks = await xendit.VirtualAccount.GetAvailableBanksAsync();    
```    
    
#### Get a fixed virtual account by ID    
    
```csharp    
var va = await xendit.VirtualAccount.GetAsync("EXAMPLE_ID");    
```    
    
#### Expire a fixed virtual account    
    
```csharp    
var expiredVA = await xendit.VirtualAccount.ExpireAsync("EXAMPLE_ID");    
```    
    
[Back to top](#table-of-contents)    
    
### Batch Disbursement Services    
    
#### Batch disbursement item    
    
```csharp    
var item = new XenditBatchDisbursementCreateRequestItem    
{    
    ExternalId = "My Disb item Id 1",    
    Amount = 10000,    
    BankCode = XenditDisbursementBankCode.BRI_SYR,    
    AccountHolderName = "Buye Loku",    
    AccountNumber = "1234567890",    
    Description = "Description for the item disbursement",    
    EmailTo = new string[] { "buye.loku@example.com", "email2@example.com" }    
};    
```    
    
#### Create a batch disbursement    
    
```csharp    
var batchDisbursement = await xendit.Disbursement.CreateBatchAsync(new XenditBatchDisbursementCreateRequest    
{    
    Reference = "My reference Id",    
    Disbursements = new List<XenditBatchDisbursementCreateRequestItem> { /* put the items here */ }    
});    
```    
    
#### Get banks with available disbursement service    
    
```csharp    
var availableDisbBanks = await xendit.Disbursement.GetAvailableBanksAsync();    
```    
    
[Back to top](#table-of-contents)  

### E-Wallet Services

#### Create a LinkAja payment

```csharp
var linkAjaPaymentItems = new List<XenditEWalletCreateLinkAjaPaymentRequestItem>
{
    new XenditEWalletCreateLinkAjaPaymentRequestItem
    {
        Id = "id_test_karton123",
        Name = "Kertas Karton",
        Price = 15000,
        Quantity = 2
    }
};

var linkAjaPayment = new XenditEWalletCreateLinkAjaPaymentRequest
{
    ExternalId = "linkaja-ewallet-1234",
    Amount = 30000,
    CallbackUrl = "https://example.com/callback_url",
    RedirectUrl = "https://example.com/redirect_url",
    Phone = "089911111111",
    Items = linkAjaPaymentItems
};

var linkAjaPaymentResponse = await xendit.EWallet.CreateLinkAjaPaymentAsync(linkAjaPayment);
```

#### Create a Dana payment

```csharp
var danaPayment = new XenditEWalletCreateDanaPaymentRequest
{
    ExternalId = "dana-ewallet-1234",
    Amount = 25000,
    CallbackUrl = "https://example.com/callback",
    RedirectUrl = "https://example.com/redirect"
};

var danaPaymentResponse = await xendit.EWallet.CreateDanaPaymentAsync(danaPayment);
```

#### Create an OVO payment

```csharp
var ovoPayment = new XenditEWalletCreateOvoPaymentRequest
{
    ExternalId = "ovo-ewallet-1234",
    Amount = 12500,
    Phone = "088889998888"
};

var ovoPaymentResponse = await xendit.EWallet.CreateOvoPaymentAsync(ovoPayment);
```

You can use other Xendit API version for OVO using `ApiVersion` property of `XenditEWalletCreateOvoPaymentRequest`, by default it uses the latest version. You can access the predefined versions using `XenditEWalletOvoVersion` class. If you are using Visual Studio or Visual Studio Code, you should be able to see the summary of each version.

#### Get an e-wallet payment

```csharp
var payment = await xendit.EWallet.GetPaymentStatusAsync("ovo-ewallet-1234", XenditEWalletType.OVO);
```

[Back to top](#table-of-contents)  
    
## Exception Handling    
    
This library throws exception with type `XenditHttpResponseException` when the API response is not successful (non `2xx` HTTP status code).    
There are some properties of this serializable exception that you can use to track problems related with API request and response.    
In order to get response content to know what Xendit API says about the response, you can just use `Content` property, you may also want to deserialize it for your need.    
    
Normally these exception's properties are enough to investigate what really happened to the request and response of the corresponding API call, although a bit expensive.    
    
## Contributing    
    
### TODO    
    
1. There are some Xendit's API endpoints that haven't been implemented to this library:  
    - Balance  
    - Credit Card  
    - Cardless Transaction  
    - Retail Outlets  
    - Invoices  
    - Recurring Payments  
    - Payouts  

2. CI/CD  
  
We welcome any contributions to this project. :)