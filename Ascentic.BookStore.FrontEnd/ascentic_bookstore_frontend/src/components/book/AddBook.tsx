import * as React from 'react';
import { RouteComponentProps, withRouter } from 'react-router-dom';
import axios from 'axios';

import 'antd/dist/antd.css';
import { FormComponentProps } from "antd/lib/form";
import { Form, Input, Button,Select,AutoComplete,Tag } from 'antd';


const { Option } = Select;
const InputGroup = Input.Group;

const dataSource = ['Burns Bay Road', 'Downing Street', 'Wall Street'];

export interface IValues {
    [key: string]: any;
}
export interface IFormState {
    id: number;
    book: any;
    addedAuthors:any;
    addedCategories:any;
    values: IValues[];
    submitSuccess: boolean;
    loading: boolean;
    formLayout:any;
    categoriesList:any;
    authorsList:any;
    form: any;
    postingData:any;
    
}
type Props=RouteComponentProps<any> & FormComponentProps
class AddBook extends React.Component<Props, IFormState> {
    constructor(props: any) {
        super(props);
        this.state = {
            id: this.props.match.params.id,
            book: {},
            values: [],
            loading: false,
            submitSuccess: false,
            formLayout: 'horizontal',
            categoriesList:[],
            authorsList:[],
            addedAuthors:[],
            addedCategories:[],
            form: {},
            postingData:{}
            
        }
    }
    
    public componentDidMount(): void {

        const config = {
            headers: { Authorization: `Bearer ${localStorage.getItem('AccessToken')}`}
        };

        axios.get(`https://localhost:5001/api/Category`,config).then(data => {
            this.setState({ categoriesList: data.data });
        }).catch(err=>{
            this.HandleError(err);
          })

        axios.get(`https://localhost:5001/api/Author`,config).then(data => {
            this.setState({ authorsList: data.data });
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
            "bookCategory": this.state.addedCategories,
            "bookAuthor": this.state.addedAuthors  
        }
         

        let config = {
            headers: {
                'Content-Type': 'application/json; charset=utf-8',
                'Access-Control-Allow-Origin': '*',
                Authorization: `Bearer ${localStorage.getItem('AccessToken')}`
            }
        }

       console.log(this.state.values);
       
       axios.post(`https://localhost:5001/api/Book`, ValueData,config).then(data => {
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





      RemoveAuthor=(author:any) => {
        let AuthorData = this.state.addedAuthors;
        let index =AuthorData.findIndex((obj:any) => obj.author.id === author.id);
        if (index !== -1) {
            AuthorData.splice(index, 1);
            this.setState({addedAuthors: AuthorData});
        }
        console.log(this.state.addedAuthors)
      }


      AddAuthor = (authorName: React.FormEvent<HTMLInputElement>) => {
        let AuthorData = this.state.addedAuthors;
        let authorList=this.state.authorsList;
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
                this.setState({addedAuthors: AuthorData});
            }
        }
        else{
            let newAuthor={
                author:{

                    categoryName:authorName
                }
            }
            AuthorData.push(newAuthor);
            this.setState({addedAuthors: AuthorData});
        }
        console.log(this.state.addedAuthors);
      }



      RemoveCategory=(category:any) => {
        let categoryData = this.state.addedCategories;
        let index =categoryData.findIndex((obj:any) => obj.category.id === category.id);
        if (index !== -1) {
            categoryData.splice(index, 1);
            this.setState({addedCategories: categoryData});
        }
        console.log(this.state.addedCategories)
      }


      AddCategory = (categoryName: React.FormEvent<HTMLInputElement>) => {
        let categoryData = this.state.addedCategories;
        let categoryList=this.state.categoriesList;
        let categoryIndex=categoryList.findIndex((obj:any) => obj.categoryName === categoryName)
        if(categoryIndex!==-1){
            let categoryDetails=categoryList[categoryIndex];
            let isCategoryExists=categoryData.findIndex((obj:any) => obj.category.id === categoryDetails.id);
            if(isCategoryExists===-1){
                let newCategory={
                    categoryId:categoryDetails.id,
                    category:categoryDetails
                }
                categoryData.push(newCategory);
                this.setState({addedCategories: categoryData});
            }
        }
        else{
            let newCategory={
                category:{
                    categoryName:categoryName
                }
            }
            categoryData.push(newCategory);
            this.setState({addedCategories: categoryData});
        }
        console.log(this.state.addedCategories);
      }


    public render() {
        const { submitSuccess, loading } = this.state;
        const { formLayout,book,categoriesList,authorsList,addedAuthors,addedCategories } = this.state;

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
                {this.state.book &&
                    <div>

                        <div>
                            <div className={"col-md-12 form-wrapper"}>
                                <h2> Add a Book </h2>
                               

                                {submitSuccess && (
                                    <div className="alert alert-info" role="alert">
                                        Book details has been edited successfully </div>
                                )}        
                                <Form layout={formLayout} onSubmit={this.processFormSubmission} noValidate={true}>
                                    <Form.Item label="Title" {...formItemLayout}>
                                        {getFieldDecorator("title", {
                                            })(
                                                <Input name="title" id="title" placeholder="Enter book title" onChange={this.handleInputChanges}/>
                                            )
                                        }
                                    </Form.Item>
                                    <Form.Item label="Price" {...formItemLayout}>
                                        {getFieldDecorator("price", {
                                            })(
                                                <Input name="price" id="price" placeholder="Enter book price" onChange={this.handleInputChanges}/>
                                            )
                                        }
                                    </Form.Item>
                                    <Form.Item label="Description" {...formItemLayout}>
                                        {getFieldDecorator("description", {})(
                                                <Input name="description" id="description" placeholder="Enter book description" onChange={this.handleInputChanges}/>
                                            )
                                        }
                                    </Form.Item>
                                    <Form.Item label="Category" {...formItemLayout}>
                                    <AutoComplete
                                        placeholder="Add Category"
                                        id="categoriesList"
                                        filterOption={(inputValue, option) =>
                                            option.props.children?.toString().toUpperCase().indexOf(inputValue.toUpperCase()) !== -1
                                        }
                                        onSelect={(e:any) =>this.AddCategory(e)}
                                     >
                                        {categoriesList && categoriesList.map((category:any) => (
                                            <Option value={category.categoryName} key={category.id}>{category.categoryName}</Option>
                                        ))}
                                    </AutoComplete>
                                    <div>
                                        {addedCategories && addedCategories.map((CategoryData:any) => (
                                            <Tag closable key={CategoryData.category.id} onClose={(e:any) =>this.RemoveCategory(CategoryData.category)} >{CategoryData.category.categoryName}</Tag>
                                        ))}  
                                    </div>
                                    </Form.Item>
                                    <Form.Item label="Author" {...formItemLayout}>
                                    <AutoComplete
                                        id="authorsList"
                                        placeholder="Add Author"
                                        filterOption={(inputValue, option) =>
                                            option.props.children?.toString().toUpperCase().indexOf(inputValue.toUpperCase()) !== -1
                                        }
                                        onSelect={(e:any) =>this.AddAuthor(e)}
                                     >
                                        {authorsList && authorsList.map((author:any) => (
                                            <Option value={author.name} key={author.id}>{author.name}</Option>
                                        ))}
                                    </AutoComplete>
                                    <div>
                                        {addedAuthors && addedAuthors.map((authorData:any) => (
                                            <Tag closable key={authorData.author.id} onClose={(e:any) =>this.RemoveAuthor(authorData.author)} >{authorData.author.name}</Tag>
                                        ))}  
                                    </div>
                                    </Form.Item>
                                    <Form.Item label="PhotoURL" {...formItemLayout}>
                                      {getFieldDecorator("photoURL", {})( 
                                        <Input  id="photoURL" name="photoURL" placeholder="Enter book photoURl" onChange={this.handleInputChanges}/>
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
export default Form.create()(AddBook);