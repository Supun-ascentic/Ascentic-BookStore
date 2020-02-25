import * as React from 'react';
import { RouteComponentProps, withRouter } from 'react-router-dom';
import axios from 'axios';

import 'antd/dist/antd.css';
import { FormComponentProps } from "antd/lib/form";
import { Form, Input, Button,Select,AutoComplete,Tag ,DatePicker} from 'antd';


const { Option } = Select;
const { TextArea } = Input;
const InputGroup = Input.Group;

const dataSource = ['Burns Bay Road', 'Downing Street', 'Wall Street'];

export interface IValues {
    [key: string]: any;
}
export interface IFormState {
    id: number;
    author: any;
    addedBooks:any;
    values: IValues[];
    submitSuccess: boolean;
    loading: boolean;
    formLayout:any;
    bookList:any;
    form: any;
    postingData:any;
    
}
type Props=RouteComponentProps<any> & FormComponentProps
class AddAuthor extends React.Component<Props, IFormState> {
    constructor(props: any) {
        super(props);
        this.state = {
            id: this.props.match.params.id,
            author: {},
            values: [],
            loading: false,
            submitSuccess: false,
            formLayout: 'horizontal',
            bookList:[],
            addedBooks:[],
            form: {},
            postingData:{}
            
        }
    }
    
    public componentDidMount(): void {

        const config = {
            headers: { Authorization: `Bearer ${localStorage.getItem('AccessToken')}`}
        };


        axios.get(`https://localhost:44359/api/Book`,config).then(data => {
            this.setState({ bookList: data.data });
        }).catch(err=>{
            this.HandleError(err);
          })
    }

    RedirectToLogin() {
        this.props.history.push("/login");
    }
  
      HandleError(err:any){
        if(err.response.status==401){
          this.RedirectToLogin();
        }
        else{
          console.log(err)
        }
      }

    private processFormSubmission = async (e: React.FormEvent<HTMLFormElement>): Promise<void> => {
        e.preventDefault();
        this.setState({ loading: true });
       // let ValueData = this.state.values;
        

        let ValueData={ ...this.state.values, 
            "bookAuthor": this.state.addedBooks  
        }
         

        let config = {
            headers: {
                'Content-Type': 'application/json; charset=utf-8',
                'Access-Control-Allow-Origin': '*',
                Authorization: `Bearer ${localStorage.getItem('AccessToken')}`
            }
        }

       console.log(this.state.values);
       
       axios.post(`https://localhost:44359/api/Author`, ValueData,config).then(data => {
            this.setState({ submitSuccess: true, loading: false })
            setTimeout(() => {
                this.props.history.push('/');
            }, 1500)
        }).catch(err=>{
            this.HandleError(err);
          })
    }

    private setValues = (values: IValues) => {
        this.setState({ values: { ...this.state.values, ...values } });
    }
    private handleInputChanges = (e: React.FormEvent<HTMLInputElement>) => {
        e.preventDefault();
        this.setValues({ [e.currentTarget.id]: e.currentTarget.value })
    }

    private handleTextAreaChanges = (e: React.FormEvent<HTMLTextAreaElement>) => {
        e.preventDefault();
        this.setValues({ [e.currentTarget.id]: e.currentTarget.value })
    }


    private OnBirthDayChanged = (date:any, dateString:string) => {
        this.setValues({ ["BirthDay"]: dateString })
    }





      RemoveBook=(book:any) => {
        let AuthorData = this.state.addedBooks;
        let index =AuthorData.findIndex((obj:any) => obj.author.id === book.id);
        if (index !== -1) {
            AuthorData.splice(index, 1);
            this.setState({addedBooks: AuthorData});
        }
        console.log(this.state.addedBooks)
      }


      AddBook = (authorName: React.FormEvent<HTMLInputElement>) => {
        let AuthorData = this.state.addedBooks;
        let authorList=this.state.bookList;
        let authorIndex=authorList.findIndex((obj:any) => obj.name === authorName)
        if(authorIndex!==-1){
            let authorDetails=authorList[authorIndex];
            let isAuthorExists=AuthorData.findIndex((obj:any) => obj.author.id === authorDetails.id);
            if(isAuthorExists===-1){
                let newAuthor={
                    authorId:authorDetails.id,
                    author:authorDetails
                }
                AuthorData.push(newAuthor);
                this.setState({addedBooks: AuthorData});
            }
        }
        else{
            let newAuthor={
                author:{

                    categoryName:authorName
                }
            }
            AuthorData.push(newAuthor);
            this.setState({addedBooks: AuthorData});
        }
        console.log(this.state.addedBooks);
      }





    public render() {
        const { submitSuccess, loading } = this.state;
        const { formLayout,author,bookList,addedBooks } = this.state;

        const { getFieldDecorator, getFieldValue } = this.props.form; 
        
        const formItemLayout =
            formLayout === 'horizontal'
                ? {
                    labelCol: { span: 4 },
                    wrapperCol: { span: 14 },
                }
                : null;
            const buttonItemLayout =
            formLayout === 'horizontal'
                ? {
                    wrapperCol: { span: 14, offset: 4 },
                }
                : null;
        return (
            <div className="App">
                {this.state.author &&
                    <div>

                        <div>
                            <div className={"col-md-12 form-wrapper"}>
                                <h2> Add a Book </h2>
                               

                                {submitSuccess && (
                                    <div className="alert alert-info" role="alert">
                                        Author details has been edited successfully </div>
                                )}        
                                <Form layout={formLayout} onSubmit={this.processFormSubmission} noValidate={true}>
                                    <Form.Item label="Name" {...formItemLayout}>
                                        {getFieldDecorator("name", {
                                            })(
                                                <Input name="name" id="name" placeholder="Enter author name" onChange={this.handleInputChanges}/>
                                            )
                                        }
                                    </Form.Item>
                                    <Form.Item label="Birthday" {...formItemLayout}>
                                         <DatePicker name="birthday" id="birthday"  onChange={this.OnBirthDayChanged}/>
                                    </Form.Item>
                                    <Form.Item label="Birthplace" {...formItemLayout}>
                                        {getFieldDecorator("birthplace", {})(
                                                <Input name="birthplace" id="birthplace" placeholder="Enter Author's birthplace" onChange={this.handleInputChanges}/>
                                            )
                                        }
                                    </Form.Item>
                                    <Form.Item label="Book" {...formItemLayout}>
                                    <AutoComplete
                                        id="bookList"
                                        placeholder="Add Book"
                                        filterOption={(inputValue, option) =>
                                            option.props.children?.toString().toUpperCase().indexOf(inputValue.toUpperCase()) !== -1
                                        }
                                        onSelect={(e:any) =>this.AddBook(e)}
                                     >
                                        {bookList && bookList.map((book:any) => (
                                            <Option value={book.title} key={book.id}>{book.title}</Option>
                                        ))}
                                    </AutoComplete>
                                    <div>
                                        {addedBooks && addedBooks.map((bookData:any) => (
                                            <Tag closable key={bookData.author.id} onClose={(e:any) =>this.RemoveBook(bookData.book)} >{bookData.book.title}</Tag>
                                        ))}  
                                    </div>
                                    </Form.Item>
                                    <Form.Item label="Facts" {...formItemLayout}>
                                        {getFieldDecorator("facts", {})(
                                                <TextArea rows={4} name="facts" id="facts" placeholder="Enter Facts about Author" onChange={this.handleTextAreaChanges}/>
                                            )
                                        }
                                    </Form.Item>
                                    <Form.Item label="PhotoURL" {...formItemLayout}>
                                      {getFieldDecorator("photoURL", {})( 
                                        <Input  id="photoURL" name="photoURL" placeholder="Enter author's photoURl" onChange={this.handleInputChanges}/>
                                      )}
                                    </Form.Item>
                                    <Form.Item {...formItemLayout}>
                                        <Button type="primary" htmlType="submit">Add</Button>
                                    </Form.Item>
                                    </Form>
                            </div>
                        </div>
                    </div>
                }
            </div>
        )
    }
}
//export default withRouter(EditBook)
export default Form.create()(AddAuthor);