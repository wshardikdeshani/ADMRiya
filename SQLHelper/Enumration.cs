using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHelper
{
    public class Enumration
    {
        public enum UserType
        {
            Admin = 1,
            Client = 2
        }

        public enum UploadFolders
        {
            Banner,
            Category,
            SubCategory,
            Voucher
        }

        public enum EmailType
        {
            AdminOTP = 1,
            ContactUsThanks = 2,
            FailPayment = 3,
            FLPUnblockByAdmin = 4,
            ForgotPasswordViaApp = 5,
            ForgotPasswordViaWeb = 6,
            FPLAutoBlock = 7,
            FPLBlockByAdmin = 8,
            PendingPayment = 9,
            RegistrationInCompleteViaApp = 10,
            RegistrationInCompleteViaWeb = 11,
            RegistrationViaApp = 12,
            RegistrationViaAppSocial = 13,
            RegistrationViaWeb = 14,
            RegistrationViaWebSocial = 15,
            SuccessAutoSend = 16,
            SuccessManualSend = 17,
            SuccessWithFailVoucherAutoSend = 18,
            SuccessWithLargeAmountAdmin = 19,
            SuccessWithLargeAmountClient = 20,
            SupportThanks = 21,
            FCMNotification = 22,
            ResendConfimationViaApp = 23,
            ResendConfirmationViaWeb = 24,
            SuccessWithPendingVoucherAutoSend = 25,
            SMS = 26,
            VoucherReceiverEmail = 27,
            VoucherSenderEmail = 28,
            VoucherClaimEmailToSender = 29
        }

        public enum RegisterVia
        {
            WEB,
            ANDROID,
            IPHONE
        }

        public enum RegisterSource
        {
            GiftCard,
            Facebook,
            Google,
        }
    }
}
