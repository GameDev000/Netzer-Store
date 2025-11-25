<div dir="rtl" lang="he">

<div class="box">
    <h2>Netzer Store – תיאור כללי</h2>
    <p>
        זהו פרוטוטייפ דו־ממדי המדגים את תהליך הליבה של משחק ניהול זמן בחנות נוחות.
        השחקן שולט במוכר, אוסף מוצרים מהמדף, מגיש אותם ללקוחות,
        ומנסה לשרת 3 לקוחות ברצף כדי להרוויח כסף.
    </p>
</div>

<div class="box">
    <h2>תהליך הליבה</h2>
    <ul>
        <li>הלקוח נכנס מהחלק העליון של המסך ועומד ליד הקופה.</li>
        <li>השחקן זז בחנות בעזרת החיצים/‏WASD.</li>
        <li>השחקן ניגש למדף ולוחץ <strong>E</strong> כדי לקחת מוצר.</li>
        <li>המוצר "נדבק" לשחקן ומלווה אותו עד הקופה.</li>
        <li>בקופה השחקן לוחץ <strong>E</strong> שוב כדי להגיש את המוצר ללקוח.</li>
        <li>הכסף עולה, הלקוח יוצא — ונכנס הלקוח הבא.</li>
        <li>אחרי 3 לקוחות השלב מסתיים.</li>
    </ul>
</div>

<div class="box">
    <h2>איך מפעילים?</h2>
    <ul>
        <li>פותחים את הפרויקט ב־Unity.</li>
        <li>מריצים את הסצנה הראשית: <strong>Scenes/Level1_Tutorial</strong>.</li>
        <li>עוקבים אחרי מונה הכסף בצד המסך.</li>
        <li>משתמשים ב־E כדי לאסוף ולהגיש מוצרים.</li>
    </ul>
</div>

<div class="box">
    <h2>ארכיטקטורת קוד</h2>
    <ul>
        <li><strong>Player/PlayerController:</strong> תנועה באמצעות Input System.</li>
        <li><strong>Player/PlayerInventory:</strong> החזקת מוצר ולוגיקת איסוף/מסירה.</li>
        <li><strong>Customer/Customer:</strong> תנועת לקוח לנקודת היעד וקבלת מוצר.</li>
        <li><strong>Managers/CustomerManager:</strong> יצירת לקוחות וניהול זרימת התור.</li>
        <li><strong>Shop/Shelf:</strong> יצירת מוצר חדש כששחקן לוחץ E באזור המדף.</li>
        <li><strong>Shop/Checkout:</strong> זיהוי השחקן והגשת מוצר ללקוח.</li>
        <li><strong>Managers/GameManager:</strong> ניהול הכסף והסקור הכולל.</li>
    </ul>
</div>

<div class="box" style="text-align:center;">
    <h2>תרשים UML</h2>

<pre style="display:inline-block; text-align:left;">
+-------------------------+       +----------------------+
|      GameManager        |       |      Customer        |
+-------------------------+       +----------------------+
| - money                 |       | - targetPosition     |
+-------------------------+       | - moveSpeed          |
| +AddMoney()             |       +----------------------+
+-------------+-----------+       | +SetTarget()         |
              ^                   | +ReceiveProduct()    |
              |                   | +LeaveAfterDelay()   |
+-------------+-----------+       +-----------+----------+
|     Checkout            |                   ^
+-------------------------+                   |
| +OnTriggerStay()        |        +----------+----------+
+-------------+-----------+        |     CustomerManager |
              ^                    +----------------------+
              |                    | - customersServed    |
+-------------+-----------+        | - maxCustomers       |
|     PlayerInventory     |        +----------------------+
+-------------------------+        | +SpawnNextCustomer() |
| - isHolding             |        +----------------------+
| - heldProduct           |
| +PickProduct()          |
| +DropProduct()          |
+-------------+-----------+
              ^
              |
+-------------+-----------+
|    PlayerController     |
+-------------------------+
| - speed                 |
| +Update()               |
| +FixedUpdate()          |
+-------------------------+

+-------------------------+
|         Shelf           |
+-------------------------+
| - productPrefab         |
| +OnTriggerStay()        |
+-------------------------+
</pre>
</div>

<div class="box">
    <h2>סיכום</h2>
    <p>
        הפרוטוטייפ מציג בצורה ברורה את תהליך הליבה של Netzer Store:
        תנועה, איסוף מוצרים, תור לקוחות, הגשה, רווחים וזרימה בסיסית של משחק ניהול זמן.
        העיצוב בסיסי בכוונה — הפוקוס הוא על משחקיות ולא גרפיקה.
    </p>
</div>
</body>
<a href="https://ron-av.itch.io/netzerstoreprototype">ITCH</a>
</div>
