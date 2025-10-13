Imports System.Xml
' CreatedDate   : 2017/06/12
' CreatedBy     : van.nnt
' XMLProcessing : Read/Write/GetAttribute/GetElement in XML File Template
Partial Public Class XMLProcessing
    'xml structure as below: 
    '<root>
    '    <name attribute1="attributevalue11" attribute2="attributevalue12" attribute3="attributevalue13"> 
    '        <element1>elementvalue11</element1> 
    '        <element2>elementvalue12</element2> 
    '        <element3>elementvalue13</element3> 
    '        <element4>elementvalue14</element4> 
    '    </name>
    '    <name attribute1="attributevalue21" attribute2="attributevalue22" attribute3="attributevalue23"> 
    '        <element1>elementvalue21</element1> 
    '        <element2>elementvalue22</element2> 
    '        <element3>elementvalue23</element3> 
    '    </name>
    '</root>
    Public __selectedNodes As String = "/root/name"

    ' Get ElementNode List From XML File By input AttributeName and AttributeValue
    ' GetElementWithXMLDoc(pathstring, "index", "1", "column_name") <name index="1> ElementNode List </name>
    Public Function GetXMLElementValue(ByVal pPathstring As String, ByVal pSelectedNodes As String, ByVal pAttributeNamedItem As String, ByVal pAttributeValue As String, ByVal pElementColumn As String) As String
        Try
            Dim m_xmld As XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode
            'Create the XML Document
            m_xmld = New XmlDocument()
            'Load the Xml file
            m_xmld.Load(pPathstring)
            'Get the list of name nodes 
            m_nodelist = m_xmld.SelectNodes(pSelectedNodes) 'xml show: <root><name attribute1="attributevalue1" attribute2="attributevalue2"> elementlist </name> </root>
            'Loop through the nodes
            For Each m_node In m_nodelist
                Dim childnodecount = m_node.ChildNodes.Count.ToString()
                Dim attributeValue = m_node.Attributes.GetNamedItem(pAttributeNamedItem).Value ' pAttributeNamedItem(~index), value~1 ==> xml show:  index="1"
                If attributeValue.ToLower() = pAttributeValue.ToLower() Then
                    'Dim elementName As String
                    Dim childNodeInnerText As String
                    Dim iCNode As Integer
                    For iCNode = 0 To m_node.ChildNodes.Count
                        'elementName = m_node.ChildNodes.Item(iCNode).Name '<column_name>
                        If m_node.ChildNodes.Item(iCNode).Name.ToLower() = pElementColumn.ToLower() Then
                            childNodeInnerText = m_node.ChildNodes.Item(iCNode).InnerText.ToLower() '<column_name>employee_id</column_name>
                            Return childNodeInnerText
                        End If
                    Next iCNode
                End If
            Next
        Catch errorVariable As Exception
            errorVariable.ToString()
        End Try
        Return ""
    End Function

    ' Get ElementNode List From XML File By input AttributeName and AttributeValue
    ' GetElementWithXMLDoc(pathstring, "index", "1", "column_name") <name index="1> ElementNode List </name>
    Public Function GetXMLElementValueList(ByVal pPathstring As String, ByVal pSelectedNodes As String, ByVal pElementColumn As String) As ArrayList
        Try
            Dim m_xmld As XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode
            'Create the XML Document
            m_xmld = New XmlDocument()
            'Load the Xml file
            m_xmld.Load(pPathstring)
            'Get the list of name nodes 
            m_nodelist = m_xmld.SelectNodes(pSelectedNodes) 'xml show: <root><name attribute1="attributevalue1" attribute2="attributevalue2"> elementlist </name> </root>
            'Loop through the nodes

            Dim arr As New ArrayList
            For Each m_node In m_nodelist
                'Dim childnodecount = m_node.ChildNodes.Count.ToString()
                'Dim attributeValue = m_node.Attributes.GetNamedItem(pAttributeNamedItem).Value ' pAttributeNamedItem(~index), value~1 ==> xml show:  index="1"
                'If attributeValue = pAttributeValue Then
                'Dim elementName As String
                Dim childNodeInnerText As String
                Dim iCNode As Integer
                For iCNode = 0 To m_node.ChildNodes.Count - 1
                    'elementName = m_node.ChildNodes.Item(iCNode).Name '<column_name>
                    If m_node.ChildNodes.Item(iCNode).Name.ToLower() = pElementColumn.ToLower() Then
                        childNodeInnerText = m_node.ChildNodes.Item(iCNode).InnerText.ToLower() '<column_name>employee_id</column_name>
                        arr.Add(childNodeInnerText)
                        'Return childNodeInnerText
                    End If
                Next iCNode
                'End If
            Next
            Return arr
        Catch errorVariable As Exception
            errorVariable.ToString()
        End Try
        Return New ArrayList
    End Function

    Public Function GetXMLAttributeValueList(ByVal pPathstring As String, ByVal pSelectedNodes As String, ByVal pAttributeNamedItem As String) As ArrayList
        Try
            Dim m_xmld As XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode
            'Create the XML Document
            m_xmld = New XmlDocument()
            'Load the Xml file
            m_xmld.Load(pPathstring)
            'Get the list of name nodes 
            m_nodelist = m_xmld.SelectNodes(pSelectedNodes) 'xml show: <root><name attribute1="attributevalue1" attribute2="attributevalue2"> elementlist </name> </root>
            Dim arrAttValue As New ArrayList
            'Loop through the nodes
            Dim attributeValue As String
            For Each m_node In m_nodelist

                attributeValue = m_node.Attributes.GetNamedItem(pAttributeNamedItem).Value.ToString().ToLower() ' pAttributeNamedItem(~index), value~1 ==> xml show:  index="1"
                'If attributeValue = pAttributeValue Then
                arrAttValue.Add(attributeValue)
            Next
            Return arrAttValue
        Catch errorVariable As Exception
            errorVariable.ToString()
        End Try
        Return New ArrayList
    End Function

    ' Get from xml file: input (attributename, attributevalue) -> If there is a node with input --> output: get attributevalue of an attributenameitem
    ' <attributen><>
    Public Function GetXMLAttributeValue(ByVal pPathstring As String, ByVal pSelectedNodes As String, ByVal pAttributeNamedKey As String, ByVal pAttributeValueKey As String, ByVal pAttributeNamedItem As String) As String
        Try
            Dim m_xmld As XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode
            'Create the XML Document
            m_xmld = New XmlDocument()
            'Load the Xml file
            m_xmld.Load(pPathstring)
            'Get the list of name nodes 
            m_nodelist = m_xmld.SelectNodes(pSelectedNodes) 'xml show: <root><name attribute1="attributevalue1" attribute2="attributevalue2"> elementlist </name> </root>
            ''Dim arrAttValue As New ArrayList
            'Loop through the nodes
            'Dim attributeValue As String
            For Each m_node In m_nodelist

                'attributeValue = m_node.Attributes.GetNamedItem(pAttributeNamedKey).Value.ToString().ToLower() ' pAttributeNamedItem(~index), value~1 ==> xml show:  index="1"
                If m_node.Attributes.GetNamedItem(pAttributeNamedKey).Value.ToString().ToLower() = pAttributeValueKey.ToLower() Then
                    Return m_node.Attributes.GetNamedItem(pAttributeNamedItem).Value.ToString().ToLower()
                End If
            Next
        Catch errorVariable As Exception
            errorVariable.ToString()
        End Try
        Return ""
    End Function

    Public Function GetXMLNodeList(ByVal pPathstring As String, ByVal pSelectedNodes As String) As XmlNodeList

        Dim m_xmld As XmlDocument
        Dim m_nodelist As XmlNodeList
        'Dim m_node As XmlNode
        'Create the XML Document
        m_xmld = New XmlDocument()
        'Load the Xml file
        m_xmld.Load(pPathstring)
        'Get the list of name nodes 
        m_nodelist = m_xmld.SelectNodes(pSelectedNodes) '/root/name
        Return m_nodelist

    End Function

    Public Function ReadInnerXml(ByVal pPathstring As String, ByVal pSelectedNode As String) As String
        Try
            Dim xmlR As XmlReader = New XmlTextReader(pPathstring)
            While (xmlR.Read())
                Dim type = xmlR.NodeType
                If (type = XmlNodeType.Element) Then
                    'If (xmlR.Name = "name") Then
                    If (xmlR.Name.ToLower() = pSelectedNode.ToLower()) Then
                        Return xmlR.ReadInnerXml.ToString()
                    End If
                End If
            End While
        Catch errorVariable As Exception
            'Error trapping
            errorVariable.ToString()
        End Try
        Return ""
    End Function
End Class
