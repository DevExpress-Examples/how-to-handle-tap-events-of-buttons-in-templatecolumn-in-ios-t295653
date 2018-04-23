# How to handle tap events of buttons in TemplateColumn in iOS


<p>It is impossible to tap buttons that are located in DisplayTemplate of TemplateColumns in iOS, so they don't raise Clicked events and commands.</p>


<h3>Description</h3>

<p>All gesture events that happen in the GridControl should be handled by this control. So, it is required to set the InputTransparent property of all cells to <strong>true</strong>. In this case, in iOS, Xamarin.Forms don't allow your buttons to handle tap gestures.&nbsp;If you have an object based on which you create a DataTemplate for your TemplateColumn, you can find the CellView object (this is its parent) and set&nbsp;its&nbsp;InputTransparent property&nbsp;to&nbsp;<strong>false</strong> as in the attached example.</p>

<br/>


