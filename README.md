# ADM - Airline Debit Memo Management Tool

# Project Introduction

ADM is used to manage airline debit memos using airline ticket numbers or airline IATA numbers.

**Modules**

Dashboard

- Display status wise ticket count
- Filter tickets if user click on the status
- Filter tickets by ticket number, ADM raised to date, status, reason, and branch wise
- Role wise manage dashboard ticket table
- Add new ADM from the dashboard
- Export data to excel

ADM

- Add new ADM
- Search ADM using ticket/IATA wise
- Upload single file while adding new ADM
- Change status active/deactivate of ADM record
- Soft ADM delete
- Edit ADM

**Note: If new ADM raised we send an email to that branch with the ADM detail. For getting emails we use "Branch Email Master".**

Reason Master

- There some fixed reasons for getting ADM so here we create a master for that. With Add/Edit/Delete functions.

Status Master

- There are some fixed statuses to manage ADM. So we create a status master with Add/Edit functions.

**Use Of Status**

- New

Use: By default select this status when raised a new ADM.

- Pending

- Use: If the user starts working on the ADM he set status pending. It means users take this ADM and start working on it.

- Debit to Riya

- Use: If the main status is **ACM Received** then the user can select this status. The use of this status is to manage the ADM amount is e.g. Total ADM is 5000 and the ACM Received **(Refund by airline)** 3000 then what about 2000 at that time user select Debit to Riya it means 2000 debit from **Riya** account.

- Debit to Sub Agent

Use: If the main status is **ACM Received** then the user can select this status. The use of this status is to manage the ADM amount is e.g. Total ADM is 5000 and the ACM Received **(Refund by airline)** 3000 then what about 2000 at that time user select Debit to Sub Agent it means 2000 debit from **Sub Agent** account.

- Dispute

Use: In this status no effect with the record.

- ACM Received

Use: ACM Received means get a refund from the airline. Now after this status there is 2 sub status of this record.

1. Partial ACM Received - Debit to Riya
2. Partial ACM Received - Debit to Sub Agent

**Note: use of these statuses already added**

- ADM Deleted

Use: Set ADM record status as ADM Deleted

- Partial ACM Received - Debit to Riya

- Use: If ADM status is ACM Received then we display sub status dropdown in follow up dialog. If the user selects this status we display another dialog for select debit from **Staff/Riya** If the user selects Staff then displays one empty box for manually write the staff name. If select Riya then by default set **Company Account** in the database.

- e.g. If ADM total amount is 5000 and ACM received 3000. So who is responsible for these 2000. If Riya debit this amount from the sub-agent account then sub-agent say I am not responsible for that amount or I am not paying this amount. So Riya gives the option to sub-agent. Part this 2000 and tell sub-agent that 1000 cut from your account. And the remaining (amount) 1000 cut from Riya's account or staff salary.

- Partial ACM Received - Debit to Sub Agent

- Use: If ADM status is ACM Received then we display sub status dropdown in follow up dialog. If the user selects this status we display another dialog for select debit from **Sub Agent**  then display one empty box for manually write the sub-agent name. It means some amount cut from a sub-agent account and the remaining amount cut from Riya's account by default

- e.g. If ADM total amount is 5000 and ACM received 3000. So who is responsible for these 2000. If Riya debit this amount from the sub-agent account then sub-agent say I am not responsible for that amount or I am not paying this amount. So Riya gives the option to sub-agent. Part this 2000 and tell sub-agent that 1000 cut from your account. And the remaining (amount) 1000 cut from Riya's account.

Branch Email Master

- In branch email master when ADM raised we need to send emails to respective branches. Here we load already exists branch from the maintained database. So the user can filter that branch and update To and CC email of that branch.

**User Roles**

- Audit Manager
- Audit User
- Branch Manager
- Branch User

**Audit Manager**

The audit Manager is one type of super admin. In this user, role user can see all the tickets in his dashboard with respective status. Also, Can search ticket by ticket number, from to date of ADM raised to date, status wise, Branch wise and reason wise.

In the audit manager dashboard, we display status, wise ticket count. If the user clicks on this count at the below table we filter that status count records.

Also, the audit manager can add new ADM and manage all masters
